using System.ComponentModel.DataAnnotations;

namespace Around.Core.Entities
{
    public class Client : User
    {
        public DriveLicense DriveLisence { get; }

        public CreditCard CreditCard { get; }
    }
}
