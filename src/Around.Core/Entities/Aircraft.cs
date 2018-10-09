using Around.Core.Enums;

namespace Around.Core.Entities
{
    public class Aircraft
    {
        public int Id { get; }

        public FlameMaterial FlameMaterial { get; }

        public bool HasFoldableDesign { get; }

        public EngineType EngineType { get; }

        public string[] Connectors { get; }
    }
}
