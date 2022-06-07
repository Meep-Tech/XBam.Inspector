using Meep.Tech.Data;

namespace Xbam.Inspector.Data {
    public partial class InspectorTabData {
        public abstract partial class Type {
            public class EnumerationsFamilyTab : Type {
                public static EnumerationsFamilyTab Id { get; }
                    = new();
                EnumerationsFamilyTab()
                    : base(nameof(EnumerationsFamilyTab)) { }

                public override string TabHilightColor
                    => "LimeGreen";

                protected override IEnumerable<TabIndexData> GetAllValidTabItems()
                    => Archetypes.DefaultUniverse.Enumerations.ByType.Keys
                        .Select(t => new TabIndexData(t));
            }
        }
    }
}
