using Meep.Tech.Data;
using Xbam.Inspector.Pages.ItemPannel.Cards.Content;

namespace Xbam.Inspector.Data {
    public partial class ArchetypeComponentCardData {
        [Branch]

    public class Type : CardData.Type.ArchetypeComponent {

      /// <summary>
      /// The id for archetype basid data cards
      /// </summary>
      public new static Identity Id {
        get;
      } = new Identity(nameof(ArchetypeCardData) + "." + nameof(ArchetypeComponentCardData.Type));

      public override System.Type CardComponentType
        => typeof(ArchetypeComponentCard);

      Type()
        : base(Id) { }
    }
  }
}