using Meep.Tech.Data;
using Xbam.Inspector.Pages.ItemPannel.Cards.Content;

namespace Xbam.Inspector.Data {
  public partial class ArchetypeCardData {

    [Branch]
    public class BasicInfoCardData : CardData.Type.XBamMetadata {

      /// <summary>
      /// The id for archetype basid data cards
      /// </summary>
      public new static Identity Id {
        get;
      } = new Identity(nameof(ArchetypeCardData) + "." + nameof(BasicInfoCardData));

      public override System.Type CardComponentType 
        => typeof(ArchetypeBasicDataCard);

      BasicInfoCardData()
        : base(Id) { }
    }
  }
}