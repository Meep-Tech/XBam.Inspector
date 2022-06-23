using Meep.Tech.Data;
using Xbam.Inspector.Pages.InitalizationErrorsPannel.Cards.Content;

namespace Xbam.Inspector.Data {
  public partial class XBamInitializationErrorCardData : CardData {

    [AutoBuild]
    public string Title {
      get;
      private set;
    }

    XBamInitializationErrorCardData() { }
  }
}