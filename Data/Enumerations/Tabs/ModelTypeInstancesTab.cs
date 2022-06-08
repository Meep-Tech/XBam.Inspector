namespace Xbam.Inspector.Data {
    public partial class InspectorTabData {
        public abstract partial class Type {
            public class ModelTypeInstancesTab : Type {
                public override string TabHilightColor 
                    => "RoyalBlue";

                public static ModelTypeInstancesTab Id { get; }
                    = new();
                ModelTypeInstancesTab()
                    : base(nameof(ModelTypeInstancesTab)) { }

                public override Dictionary<string, ItemData> LoadItems(InspectorTabData tab) {
                    throw new NotImplementedException();
                }

                public override Dictionary<string, CardData> LoadItemDataCards(InspectorTabData tab, ItemData item) {
                    throw new NotImplementedException();
                }

                protected override IEnumerable<TabIndexData> GetAllValidTabItems() => new TabIndexData[] {
                    ("Test.Type", "Testing.Prefix"),
                    ("Test.Type2", "Testing.Prefix"),
                    ("Test.Type3", "Testing.Prefix"),
                    ("Test.Type4", "Testing.Prefix"),
                    ("Test.Type5", "Testing.Prefix"),
                    ("Test.Type.Aple", "Testing.Prefix"),
                    ("Test.Typ9", "Testing.Prefix"),
                    ("Test.Ty9pe", "Testing.Prefix"),
                    ("Test.Ty9pe2", "Testing.Prefix"),
                    ("Test.Ty9pe3", "Testing.Prefix"),
                    ("Test.Typ9e4", "Testing.Prefix"),
                    ("Test.Typ9e5", "Testing.Prefix"),
                    ("Test.Ty9pe.Aple", "Testing.Prefix"),
                    ("Test.T9yp", "Testing.Prefix"),
                    ("Test.Ty9pe", "Testing.Prefix"),
                    ("Test.9Type2", "Testing.Prefix"),
                    ("Te9st.Type3", "Testing.Prefix"),
                    ("Test.9Type4", "Testing.Prefix"),
                    ("Tes6t.Type5", "Testing.Prefix"),
                    ("Tesut.Type.Aple", "Testing.Prefix"),
                    ("Test.Tuyp", "Testing.Prefix"),
                    ("Test.uType", "Testing.Prefix"),
                    ("Teust.Type2", "Testing.Prefix"),
                    ("Test.Tyupe3", "Testing.Prefix"),
                    ("Tuest.Tyupe4", "Testing.Prefix"),
                    ("Tjest.Type5", "Testing.Prefix"),
                    ("Tesht.Type.Aple", "Testing.Other"),
                    ("Test.Tykp", "Testing.Prefix"),
                    ("TepstItem", "Testing.Prefix")
                };
            }
        }
    }
}
