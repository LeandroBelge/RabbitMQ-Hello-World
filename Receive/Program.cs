using System;

namespace Receive
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = new Receiver();
            Console.WriteLine(" [*] Waiting for messages.");
            var message = receiver.ReceiveOne();
            if (message != null)
            {
                Console.WriteLine(" [x] Received {0}", message);
            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
