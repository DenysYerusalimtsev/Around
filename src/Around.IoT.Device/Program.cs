using System;
using System.Threading.Tasks;

namespace Around.IoT.Device
{
    class Program
    {
        private const string ConnectionString = "HostName=AroundIoT.azure-devices.net;DeviceId=CopterTest1;SharedAccessKey=/nqBLFvE5TJt/cF+EciiK7uz/4dO6Tga7LMWEopJW10=";
        private const string DeviceId = "CopterTest1";

        static void Main(string[] args)
        {
            var receiver = new CloudMessagesReceiver(ConnectionString);
            var sender = new CloudMessageSender(ConnectionString);

            var receiveMessages = Task.Run(async () => await receiver.Start());
            var sendTelemetry = Task.Run(async () => await sender.Start(DeviceId));

            Task.WhenAll(receiveMessages, sendTelemetry).GetAwaiter().GetResult();

            Console.WriteLine("Application STOP.");
        }
    }
}