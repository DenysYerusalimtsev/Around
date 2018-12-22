namespace Around.IoTHub.Cloud.Azure
{
    internal class BookCopterDto
    {
        public BookCopterDto(int clientId, int rentId)
        {
            ClientId = clientId;
            RentId = rentId;
        }

        public Operation Operation { get; set; } = Operation.Booked;

        public int ClientId { get; set; }

        public int RentId { get; set; }
    }
}