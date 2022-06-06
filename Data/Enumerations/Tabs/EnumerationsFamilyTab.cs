using Meep.Tech.Data;
using Meep.Tech.Data.Reflection;

namespace Xbam.Inspector.Data {
    public partial class TabData {
        public abstract partial class Type {
            public class EnumerationsFamilyTab : Type {
                public static EnumerationsFamilyTab Id { get; }
                    = new();
                EnumerationsFamilyTab()
                    : base(nameof(EnumerationsFamilyTab)) { }

                protected override IEnumerable<TabTypeData> GetAllValidTabItems()
                    => Archetypes.DefaultUniverse.Enumerations.ByType.Keys
                        .Select(t => new TabTypeData(t));
            }
        }
    }
}
