namespace Around.Core.Entities
{
    public class CreditCard
    {
        public virtual int Id { get; set; }

        public string Number { get; set; }

        public string ValidThru { get; set; }

        public string Cvv { get; set; }

        public virtual Client Client { get; set; }
    }
}
