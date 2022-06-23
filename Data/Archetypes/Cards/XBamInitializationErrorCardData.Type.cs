using Meep.Tech.Data;
using Xbam.Inspector.Pages.InitalizationErrorsPannel.Cards.Content;

namespace Xbam.Inspector.Data {
  public partial class XBamInitializationErrorCardData {
    
    [Branch]
    public new class Type : CardData.Type {
      /// <summary>
      /// The id for archetype basid data cards
      /// </summary>
      public new static Identity Id {
        get;
      } = new Identity(nameof(XBamInitializationErrorCardData) + "." + nameof(Type));

      public override System.Type CardComponentType 
        => typeof(XBamInitialzationErrorsDataCard);

      Type()
        : base(Id, "red", "orange") { }
    }
  }
}