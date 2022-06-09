using Meep.Tech.Data;
using Xbam.Inspector.Pages.ItemPannel.Cards.Content;

namespace Xbam.Inspector.Data {

  public partial class ArchetypePropertiesCardData {
    [Branch]
    public new class Type : CardData.Type.CSharpCode {

      /// <summary>
      /// The id for archetype basid data cards
      /// </summary>
      public new static Identity Id {
        get;
      } = new Identity(nameof(ArchetypePropertiesCardData) + "." + nameof(Type));

      public override System.Type CardComponentType
        => typeof(ArchetypePropertiesDataCard);

      Type()
        : base(Id) { }
    }
  }
}