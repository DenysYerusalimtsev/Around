using System.IO;
using System.Threading.Tasks;
using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface IReportRenderer
    {
        Task RenderAsync(Stream stream, Cheque cheque);
    }
}
