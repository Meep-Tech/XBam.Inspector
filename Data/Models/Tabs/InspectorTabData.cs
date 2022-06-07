using Meep.Tech.Data;

namespace Xbam.Inspector.Data {
    public partial class InspectorTabData {

        public Dictionary<string, ItemData> ItemsState {
            get;
        } = new();

        /// <summary>
        /// The data of the actual tab part of this tab.
        /// </summary>
        public TabIndexData Tab {
            get;
            init;
        }

        public Type TabType {
            get;
            init;
        }

        public string CurrentItemId {
            get;
            set;
        }
    }
}
