using Meep.Tech.Data;
using Xbam.Inspector.Pages.InitalizationErrorsPannel.Cards.Content;
using Xbam.Inspector.Pages.ItemPannel.Cards.Content;
using static Xbam.Inspector.Data.ArchetypeCardData;

namespace Xbam.Inspector.Data {

  public partial class ArchetypeCardData {
    [Branch]
    public class TraitsCardData : CardData.Type.XBamMetadata {

      /// <summary>
      /// The id for archetype basid data cards
      /// </summary>
      public new static Identity Id {
        get;
      } = new Identity(nameof(ArchetypeCardData) + "." + nameof(TraitsCardData));

      public override System.Type CardComponentType 
        => typeof(ArchetypeTraitsDataCard);

      TraitsCardData()
        : base(Id) { }
    }
  }
}