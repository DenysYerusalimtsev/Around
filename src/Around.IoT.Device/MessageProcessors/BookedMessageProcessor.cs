using Around.IoT.Device.Models;
using System;
using System.Threading.Tasks;

namespace Around.IoT.Device.MessageProcessors
{
    public class BookedMessageProcessor : IMessageProcessor<BookedMessage>
    {
        public Task Process(BookedMessage message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Device booked! Start timer.");

            return Task.CompletedTask;
        }
    }
}