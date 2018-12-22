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
                Message receivedMessage = await _client.ReceiveAsync();
                if (receivedMessage == null) continue;

                var payload = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                var message = JsonConvert.DeserializeObject<IMessage>(payload);

                await Process(message);

                await _client.CompleteAsync(receivedMessage);
            }
        }

        private async Task Process(IMessage message)
        {
            switch (message.Operation)
            {
                case Operation.Booked:
                    var processor = new BookedMessageProcessor();
                    await processor.Process(message as BookedMessage);
                    break;
            }
        }
    }
}
