using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Receive
{
    public class Receiver
    {
        private readonly string _hostName;
        public Receiver(string hostName = "localhost")
        {
            _hostName = hostName;
        }

        public string? ReceiveOne()
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            var tcs = new TaskCompletionSource<string?>();
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                tcs.TrySetResult(message);
            };
            channel.BasicConsume(queue: "hello",
                                 autoAck: true,
                                 consumer: consumer);

            tcs.Task.Wait(TimeSpan.FromSeconds(5));
            return tcs.Task.IsCompleted ? tcs.Task.Result : null;
        }
    }
}
