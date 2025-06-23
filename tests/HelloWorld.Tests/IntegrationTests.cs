using NUnit.Framework;
using Send;
using Receive;
using System.Threading.Tasks;

namespace HelloWorld.Tests
{
    public class IntegrationTests
    {
        [Test]
        public void SendAndReceiveHelloWorld()
        {
            var receiver = new Receiver();
            var receiveTask = Task.Run(() => receiver.ReceiveOne());

            var sender = new Sender();
            sender.Send("Hello World!");

            var message = receiveTask.Result;
            Assert.AreEqual("Hello World!", message);
        }
    }
}
