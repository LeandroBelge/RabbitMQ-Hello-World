using System;

namespace Send
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new Sender();
            sender.Send("Hello World!");
            Console.WriteLine(" [x] Sent {0}", "Hello World!");
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
