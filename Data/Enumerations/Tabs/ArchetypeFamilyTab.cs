using Meep.Tech.Collections.Generic;
using Meep.Tech.Data;
using Meep.Tech.Data.Reflection;

namespace Xbam.Inspector.Data {
  public partial class InspectorTabData {
    public abstract partial class Type {
      public class ArchetypeFamilyTab : InspectorFamilyTab.Type {
        public static ArchetypeFamilyTab Id { get; }
            = new();

        public override string TabHilightColor
            => "Crimson";

        ArchetypeFamilyTab()
            : base(nameof(ArchetypeFamilyTab)) { }

        protected override IEnumerable<TabIndexData> GetAllValidTabItems() {
          var nonAbstractTypes = Archetypes.DefaultUniverse.Archetypes.All.ByFullTypeName.Values
            .Select(a => a.Type);
          var allTypes = nonAbstractTypes
            .Concat(Archetypes.DefaultUniverse.Archetypes.Collections.Select(c => c.RootArchetypeType))
            .Distinct()
            .Where(t => t != null)
            .ToHashSet();

          foreach(System.Type type in nonAbstractTypes) {
            var potentialAbstractBaseType = type.BaseType;
            if (type.Name == "BuilderFactory" 
              && potentialAbstractBaseType.GetGenericArguments().LastOrDefault()?.Name == "BuilderFactory"
              && potentialAbstractBaseType.GetGenericArguments().Last().DeclaringType.Name == typeof(IComponent<>).Name
            ) {
              continue;
            }
            while (!allTypes.Contains(potentialAbstractBaseType)) {
              if (potentialAbstractBaseType.Name == typeof(Archetype<,>).Name) {
                allTypes.Add(potentialAbstractBaseType.GetGenericArguments().Last());
                break;
              }
              else {
                allTypes.Add(potentialAbstractBaseType);
              }
              potentialAbstractBaseType = type.BaseType;
            }
          }

          return allTypes.Select(t => new TabIndexData(t));
        }

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

          // Make the properties info card
          CardData propertiesCard = CardData.Types.Get<ArchetypePropertiesCardData.Type>().Make(
            (nameof(CardData.Key), "Properties and Fields"),
            (nameof(ArchetypeCardData.ForArchetype), item.Data as Archetype)
          );

          cards.Add(propertiesCard, c => c.Key);

          // Make the methods info card
          CardData methodsCard = CardData.Types.Get<ArchetypeMethodsCardData.Type>().Make(
            (nameof(CardData.Key), "Methods and Functions"),
            (nameof(ArchetypeCardData.ForArchetype), item.Data as Archetype)
          );

          cards.Add(methodsCard, c => c.Key);

          foreach (Archetype.IComponent component in (item.Data as Archetype).Components.Values) {
            // Make the properties info card
            CardData componentCard = CardData.Types.Get<ArchetypeComponentCardData.Type>().Make(
              (nameof(CardData.Key), "Component: " + component.GetType().ToFullHumanReadableNameString(false)),
              (nameof(ArchetypeComponentCardData.Component), component)
            );

            cards.Add(componentCard, c => c.Key);
          }

          return cards;
        }
      }
    }
  }
}