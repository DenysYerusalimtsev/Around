using Around.Core.Enums;
using System.Collections.Generic;

namespace Around.Core.Entities
{
    public class RemoteControl
    {
        public int Id { get; set; }

        public ControlType ControlType { get; set; }

        public bool HasBuiltInDisplay { get; set; }

        public bool HasMobileDeviceMount { get; set; }

        public string Connectors { get; set; } 

        public double MaximumRadius { get; set; }

        public virtual Copter Copter { get; set; }
    }
}
