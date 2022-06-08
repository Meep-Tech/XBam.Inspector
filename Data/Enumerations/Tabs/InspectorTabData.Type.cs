using Meep.Tech.Data;
using Meep.Tech.Data.Reflection;
using Meep.Tech.Data.Utility;

namespace Xbam.Inspector.Data {
    public partial class InspectorTabData {
        public abstract partial class Type : Enumeration<Type> {

            public virtual string TabHilightColor
                => "black";

            protected Type(string uniqueIdentifier)
                : base(uniqueIdentifier) { }

            public IEnumerable<TabIndexData> GetTabItemTypes(string optionalSearchTerm = null, bool searchNamespace = false)
                => _filterItemTypes(GetAllValidTabItems(), optionalSearchTerm?.ToLower(), searchNamespace);

            public abstract Dictionary<string, ItemData> LoadItems(InspectorTabData tab);

            public abstract Dictionary<string, CardData> LoadItemDataCards(InspectorTabData tab, ItemData item);

            protected abstract IEnumerable<TabIndexData> GetAllValidTabItems();

            protected override object UniqueIdCreationLogic(object uniqueIdentifier)
                => uniqueIdentifier.ToString().ToSentenceCase();

            IEnumerable<TabIndexData> _filterItemTypes(IEnumerable<TabIndexData> input, string searchTerm, bool searchNamespace) 
              => (searchTerm is null
                ? input
                : searchNamespace
                  ? input
                    .Where(i => $"{i.Prefix}.{i.Name}".ToLower().Contains(searchTerm))
                  : input
                    .Where(i => i.Name.ToLower().Contains(searchTerm)))
                .OrderBy(t => t.SortKey);
        }
    }
}
