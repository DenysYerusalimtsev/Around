namespace Around.Core.Entities
{
    public class CreditCard
    {
        public string Number { get; }

        public string ValidThru { get; }

        public string Cvv { get; }

        public virtual Client Client { get; set; }
    }
}
