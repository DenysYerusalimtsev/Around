namespace Around.IoTHub.Cloud.Azure
{
    internal class FreeCopterDto
    {
        public FreeCopterDto(int clientId, int rentId)
        {
            ClientId = clientId;
            RentId = rentId;
        }

        public Operation Operation { get; set; } = Operation.Free;

        public int ClientId { get; set; }

        public int RentId { get; set; }
    }
}
