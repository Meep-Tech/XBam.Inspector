using Meep.Tech.Collections.Generic;
using Meep.Tech.Data;
namespace Xbam.Inspector.Data {
  public partial class InspectorTabData {
    public abstract partial class Type {
      public class ArchetypeFamilyTab : Type {
        public static ArchetypeFamilyTab Id { get; }
            = new();

        public override string TabHilightColor
            => "Crimson";

        ArchetypeFamilyTab()
            : base(nameof(ArchetypeFamilyTab)) { }

        protected override IEnumerable<TabIndexData> GetAllValidTabItems()
          => Archetypes.DefaultUniverse.Archetypes.All.ByFullTypeName.Values
            .Select(a => a.Type)
            // TODO: this misses mid-tree abstract archetypes like "Weapon.Type" in testing.
            .Concat(Archetypes.DefaultUniverse.Archetypes.Collections.Select(c => c.RootArchetypeType))
            .Distinct()
            .Where(t => t != null)
            .Select(t => new TabIndexData(t));

        public override Dictionary<string, ItemData> LoadItems(InspectorTabData tab) {
          System.Type archetypeBaseType = System.Type.GetType(tab.Tab.FullTypeName)
              ?? throw new Exception($"Could not find the system type:{tab.Tab.Name}, using it's full name: {tab.Tab.FullTypeName}");

          Archetype.Collection collection
              = Archetypes.DefaultUniverse.Archetypes.TryToGetCollectionFor(archetypeBaseType);

          if (collection.RootArchetypeType != archetypeBaseType) {
            collection = null;
          }

          return (collection ?? Archetypes.DefaultUniverse.Archetypes.All
            .Where(a => archetypeBaseType.IsAssignableFrom(a.Type)))
              .Select(a => new ItemData {
                Name = a.Id.Name,
                Key = a.Id.Key,
                Type = a.Type,
                Data = a
              }).ToDictionary(i => i.Key);
        }

        public override Dictionary<string, CardData> LoadItemDataCards(InspectorTabData tab, ItemData item) {
          Dictionary<string, CardData> cards = new();

          // Make the main info card.
          CardData mainArchetypeInfo = CardData.Types.Get<ArchetypeCardData.BasicInfoCardData>().Make(
            (nameof(CardData.Key), "Archetype Info"),
            (nameof(ArchetypeCardData.ForArchetype), item.Data as Archetype)
          );

          cards.Add(mainArchetypeInfo, c => c.Key);

          // Make the traits info card.
          CardData archetypeTraitsCard = CardData.Types.Get<ArchetypeCardData.TraitsCardData>().Make(
            (nameof(CardData.Key), "Traits"),
            (nameof(ArchetypeCardData.ForArchetype), item.Data as Archetype)
          );

          cards.Add(archetypeTraitsCard, c => c.Key);

          return cards;
        }
      }
    }
  }
}