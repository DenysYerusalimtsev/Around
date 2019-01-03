using System;

namespace Around.IoT.Device.Models
{
    public class Telemetry
    {
        public Telemetry(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public Telemetry(string name)
        {
            Name = name;
            Latitude = 50.005651;
            Longitude = 36.229074;
        }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Telemetry ChangeState()
        {
            Random random = new Random();
            if (Latitude < 60 && Longitude < 36)
            {
                Latitude += random.Next(1, 3);
                Longitude += random.Next(1, 3);
            }
            else
            {
                Latitude -= random.Next(2, 5);
                Longitude -= random.Next(2, 4);
            }

            return this;
        }
    }
}
