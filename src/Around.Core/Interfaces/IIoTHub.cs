using System.Threading.Tasks;
using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface IIoTHub
    {
        Task StartUsingCopter(Rent rent);

        Task FinishUsingCopterAsync(Cheque cheque);
    }
}
