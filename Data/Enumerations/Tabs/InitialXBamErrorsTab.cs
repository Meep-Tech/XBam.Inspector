using Meep.Tech.Data;

namespace Xbam.Inspector.Data {
  public partial class InspectorTabData {
    public abstract partial class Type {
      public class InitialXBamErrorsTab : Type {

        public override bool ShowAsAnOptionInTheAddTabSearch
            => false;

        public static InitialXBamErrorsTab Id { get; }
          = new();

        InitialXBamErrorsTab()
          : base(nameof(InitialXBamErrorsTab)) { }

        public override string TabHilightColor
          => "Red";

        protected override IEnumerable<TabIndexData> GetAllValidTabItems()
          => throw new NotImplementedException();

        public override Dictionary<string, ItemData> LoadItems(InspectorTabData tab)
          => throw new NotImplementedException();

        public override Dictionary<string, CardData> LoadItemDataCards(InspectorTabData tab, ItemData item)
          => throw new NotImplementedException();
      }
    }
  }
}
