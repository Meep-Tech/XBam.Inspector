
namespace Xbam.Inspector.Data {
  public class ItemData {
    public string Key {
      get;
      init;
    }

    public string Name {
      get;
      init;
    }

    public System.Type Type {
      get;
      init;
    }

    public object Data {
      get;
      init;
    }

    public Dictionary<string, CardData> CardsState {
      get;
      internal set;
    }
  }
}