namespace Around.Core.Entities
{
    public class Characteristics
    {
        public virtual int Id { get; set; }

        public double AmbientTemperature { get; }

        public double Widht { get; }

        public double Length { get; }

        public double Height { get; }

        public double Weight { get; }

        public string Colour { get; }

        public double PropellersCount { get; }
    }
}
