using Meep.Tech.Data;
using Meep.Tech.Data.Reflection;
using Meep.Tech.Data.Utility;
using System.Linq;

namespace Xbam.Inspector.Data {
    public partial class InspectorTabData {
        public abstract partial class Type {
            public class ArchetypeFamilyTab : Type {
                public static ArchetypeFamilyTab Id { get; }
                    = new();

                public override string TabHilightColor 
                    => "Crimson";

                ArchetypeFamilyTab()
                    : base(nameof(ArchetypeFamilyTab)) { }

                protected override IEnumerable<TabIndexData> GetAllValidTabItems()
                    => Archetypes.DefaultUniverse.Archetypes.All.ByFullTypeName.Values
                        .Select(a => a.Type)
                        .Concat(Archetypes.DefaultUniverse.Archetypes.Collections.Select(c => c.RootArchetypeType))
                        .Distinct()
                        .Where(t => t != null)
                        .Select(t => new TabIndexData(t));
            }
        }
    }
}
