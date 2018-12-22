namespace Around.IoT.Device.Models
{
    public class FreeMessage : IMessage
    {
        public Operation Operation { get; set; }

        public int ClientId { get; set; }

        public int RentId { get; set; }
    }
}
