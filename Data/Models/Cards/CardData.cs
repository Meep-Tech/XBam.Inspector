using Meep.Tech.Data;

namespace Xbam.Inspector.Data {
    public partial class CardData {
        public string Key {
            get;
            init;
        }

        public bool IsExpanded { get; internal set; }

        public Type CardType { get; internal init; }
    }
}