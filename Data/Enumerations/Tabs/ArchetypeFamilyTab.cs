using Meep.Tech.Data;
using Meep.Tech.Data.Reflection;
using Meep.Tech.Data.Utility;

namespace Xbam.Inspector.Data {
    public partial class TabData {
        public abstract partial class Type {
            public class ArchetypeFamilyTab : Type {
                public static ArchetypeFamilyTab Id { get; }
                    = new();
                ArchetypeFamilyTab()
                    : base(nameof(ArchetypeFamilyTab)) { }

                protected override IEnumerable<TabTypeData> GetAllValidTabItems()
                    => Archetypes.DefaultUniverse.Archetypes.All.ByFullTypeName.Values
                        .Select(a => new TabTypeData(a.Type));
            }
        }
    }
}
