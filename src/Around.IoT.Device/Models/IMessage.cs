namespace Around.IoT.Device.Models
{
    public interface IMessage
    {
        Operation Operation { get; set; }

        int ClientId { get; set; }

        int RentId { get; set; }
    }
}
