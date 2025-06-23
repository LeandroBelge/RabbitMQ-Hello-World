using RabbitMQ.Client;
using System.Text;

namespace Send
{
    public class Sender
    {
        private readonly string _hostName;
        public Sender(string hostName = "localhost")
        {
            _hostName = hostName;
        }

        public void Send(string message)
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
