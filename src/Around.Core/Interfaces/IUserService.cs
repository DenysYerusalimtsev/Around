using Around.Core.Entities;

namespace Around.Core.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
