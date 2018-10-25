using Around.Core.Enums;
using System.Collections.Generic;

namespace Around.Core.Entities
{
    public class Camera
    {
        public int Id { get; set; }

        public CameraMount CameraMount { get; set; }

        public string Lens { get; set; }

        public bool HasCameraRotation { get; set; }

        public string IsoSensetivity { get; set; }

        public Resolution Resolution { get; set; }

        public string PhotoModes { get; set; }

        public Stabilization Stabilization { get; set; }

        public virtual FullCharacteristics FullCharacteristics { get; set; }
    }
}
