using Meep.Tech.Data;

namespace Xbam.Inspector.Data {
    public partial class InspectorTabData {
        public abstract partial class Type {
            public class EnumerationsFamilyTab : InspectorFamilyTab.Type {
                public static EnumerationsFamilyTab Id { get; }
                    = new();
                EnumerationsFamilyTab()
                    : base(nameof(EnumerationsFamilyTab)) { }

                public override string TabHilightColor
                    => "LimeGreen";

                protected override IEnumerable<TabIndexData> GetAllValidTabItems()
                    => Archetypes.DefaultUniverse.Enumerations.ByType.Keys
                        .Select(t => new TabIndexData(t));

                public override Dictionary<string, ItemData> LoadItems(InspectorTabData tab) {
                    throw new NotImplementedException();
                }

                public override Dictionary<string, CardData> LoadItemDataCards(InspectorTabData tab, ItemData item) {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
