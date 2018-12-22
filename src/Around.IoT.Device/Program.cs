using System;
using System.Threading.Tasks;

namespace Around.IoT.Device
{
    class Program
    {
        private const string ConnectionString = "HostName=AroundIoT.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=qttYCZnkTx2zLYZl1YPuGqUNMhBBgMy7wjEWXXZi8Hw=";

        static void Main(string[] args)
        {
            var receiver = new CloudMessagesReceiver(ConnectionString);

            Task.Run(async () => await receiver.Start()).GetAwaiter().GetResult();

            Console.WriteLine("Application STOP.");
        }
    }
}