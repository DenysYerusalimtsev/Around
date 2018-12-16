using System.IO;
using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface IReportRenderer
    {
        MemoryStream Render(Cheque cheque);
    }
}
