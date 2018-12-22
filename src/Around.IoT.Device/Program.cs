using System;
using System.Threading.Tasks;

namespace Around.IoT.Device
{
    class Program
    {
        private const string ConnectionString = "";

        static void Main(string[] args)
        {
            var receiver = new CloudMessagesReceiver(ConnectionString);

            Task.Run(async () => await receiver.Start()).GetAwaiter().GetResult();

            Console.WriteLine("Application STOP.");
        }
    }
}