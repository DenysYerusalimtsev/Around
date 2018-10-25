namespace Around.Core.Entities
{
    public class Characteristics
    {
        public virtual int Id { get; set; }

        public double AmbientTemperature { get; set; }

        public double Widht { get; set; }

        public double Length { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public string Colour { get; set; }

        public double PropellersCount { get; set; }

        public virtual FullCharacteristics FullCharacteristics { get; set; }
    }
}
