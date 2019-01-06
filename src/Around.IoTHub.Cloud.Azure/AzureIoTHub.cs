using Around.Core.Entities;
using Around.Core.Interfaces;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Around.IoTHub.Cloud.Azure
{
    public sealed class AzureIoTHub : IIoTHub
    {
        private readonly ServiceClient _serviceClient;

        public AzureIoTHub(string connectionString)
        {
            _serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
        }

        public async Task FinishUsingCopterAsync(Cheque cheque)
        {
            var dto = new FreeCopterDto(cheque.Rent.ClientId, cheque.Rent.Id);
            var json = JsonConvert.SerializeObject(dto);
            var message = new Message(Encoding.ASCII.GetBytes(json));
            message.Properties.Add("Operation", dto.Operation.ToString());
            await _serviceClient.SendAsync(HubCopterIdFor(cheque.Rent.Copter), message);
        }

        public async Task StartUsingCopter(Rent rent)
        {
            var dto = new BookCopterDto(rent.ClientId, rent.Id);
            var json = JsonConvert.SerializeObject(dto);

            var message = new Message(Encoding.ASCII.GetBytes(json));
            message.Properties.Add("Operation", dto.Operation.ToString());
            await _serviceClient.SendAsync(HubCopterIdFor(rent.Copter), message);
        }

        private string HubCopterIdFor(Copter copter) => copter.Name;
    }
}
