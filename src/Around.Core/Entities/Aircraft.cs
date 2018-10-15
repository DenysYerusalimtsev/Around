using Around.Core.Enums;

namespace Around.Core.Entities
{
    public class Aircraft
    {
        public int Id { get; set; }

        public FlameMaterial FlameMaterial { get; set; }

        public bool HasFoldableDesign { get; set; }

        public EngineType EngineType { get; set; }

        public string Connectors { get; set; }

        public virtual Copter Copter { get; set; }
    }
}
