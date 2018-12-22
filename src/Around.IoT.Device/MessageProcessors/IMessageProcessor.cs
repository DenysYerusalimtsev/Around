using System.Threading.Tasks;
using Around.IoT.Device.Models;

namespace Around.IoT.Device.MessageProcessors
{
    internal interface IMessageProcessor<in TMessage>
        where TMessage : IMessage
    {
        Task Process(TMessage message);
    }
}