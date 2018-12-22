using System;
using System.Threading.Tasks;
using Around.IoT.Device.Models;

namespace Around.IoT.Device.MessageProcessors
{
    public class FreeMessageProcessor : IMessageProcessor<FreeMessage>
    {
        public Task Process(FreeMessage message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Copter`s rental is finish!");

            return Task.CompletedTask;
        }
    }
}
