using Around.Core.Enums;
using System.Collections.Generic;

namespace Around.Core.Entities
{
    public class RemoteControl
    {
        public int Id { get; }

        public ControlType ControlType { get; }

        public bool HasBuiltInDisplay { get; }

        public bool HasMobileDeviceMount { get; }

        public List<string> Connectors { get; } 

        public double MaximumRadius { get; }

        public virtual Copter Copter { get; set; }
    }
}
