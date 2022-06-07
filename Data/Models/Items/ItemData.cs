
namespace Xbam.Inspector.Data {
    public class ItemData {
        public string Key {
            get;
            init;
        }

        public Dictionary<string, CardData> CardsState {
            get;
        } = new();
    }
}