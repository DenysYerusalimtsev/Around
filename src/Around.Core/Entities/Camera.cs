using Around.Core.Enums;
using System.Collections.Generic;

namespace Around.Core.Entities
{
    public class Camera
    {
        public int Id { get; }

        public CameraMount CameraMount { get; }

        public string Lens { get; set; }

        public bool HasCameraRotation { get; }

        public string IsoSensetivity { get; }

        public Resolution Resolution { get; }

        public List<string> PhotoModes { get; }

        public Stabilization Stabilization { get; }

        public virtual Copter Copter { get; set; }
    }
}
