using System;
using System.Threading.Tasks;

namespace Around.IoT.Device
{
    class Program
    {
        private const string ConnectionString = "HostName=AroundIoT.azure-devices.net;DeviceId=CopterTest1;SharedAccessKey=/nqBLFvE5TJt/cF+EciiK7uz/4dO6Tga7LMWEopJW10=";

        static void Main(string[] args)
        {
            var receiver = new CloudMessagesReceiver(ConnectionString);

            Task.Run(async () => await receiver.Start()).GetAwaiter().GetResult();

            Console.WriteLine("Application STOP.");
        }
    }
}