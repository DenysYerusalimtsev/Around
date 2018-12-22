using System;
using Around.IoT.Device.MessageProcessors;
using Around.IoT.Device.Models;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Around.IoT.Device
{
    internal sealed class CloudMessagesReceiver
    {
        private readonly DeviceClient _client;

        public CloudMessagesReceiver(string connectionString)
        {
            _client = DeviceClient.CreateFromConnectionString(connectionString);
        }

        public async Task Start()
        {
            while (true)
            {
                Message receivedMessage = await _client.ReceiveAsync(TimeSpan.FromSeconds(2));
                if (receivedMessage == null) continue;

                await Process(receivedMessage);

                await _client.CompleteAsync(receivedMessage);
            }
        }

        private async Task Process(Message message)
        {
            if (message.Properties.ContainsKey("Operation"))
            {
                if (Enum.TryParse(message.Properties["Operation"], out Operation oper))
                {
                    var payload = Encoding.ASCII.GetString(message.GetBytes());
                    switch (oper)
                    {
                        case Operation.Booked:
                            var bookedProcessor = new BookedMessageProcessor();
                            var bookedMessageDto = JsonConvert.DeserializeObject<BookedMessage>(payload);
                            await bookedProcessor.Process(bookedMessageDto);
                            break;

                        case Operation.Free:
                            var freeProcessor = new FreeMessageProcessor();
                            var freeMessageDto = JsonConvert.DeserializeObject<FreeMessage>(payload);
                            await freeProcessor.Process(freeMessageDto);
                            break;
                    }
                }
            }
        }
    }
}
