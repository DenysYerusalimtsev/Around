using System.IO;
using System.Threading.Tasks;

namespace Around.Core.Interfaces
{
    public interface IMailBox
    {
        Task Send(Stream attachment);
    }
}
