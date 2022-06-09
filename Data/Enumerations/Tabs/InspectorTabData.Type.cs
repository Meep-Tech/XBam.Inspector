﻿using Meep.Tech.Data;
using Meep.Tech.Data.Reflection;
using Meep.Tech.Data.Utility;
using System.Reflection;

namespace Xbam.Inspector.Data {
  public partial class InspectorTabData {
    public abstract partial class Type : Enumeration<Type> {

      public virtual string TabHilightColor
          => "black";

      protected Type(string uniqueIdentifier)
          : base(uniqueIdentifier) { }

      public IEnumerable<TabIndexData> GetTabItemTypes(string optionalSearchTerm = null, bool searchNamespace = false, bool abstractOrSplayedOnly = false)
          => _filterItemTypes(GetAllValidTabItems(), optionalSearchTerm?.ToLower(), searchNamespace, abstractOrSplayedOnly);

      public abstract Dictionary<string, ItemData> LoadItems(InspectorTabData tab);

      public abstract Dictionary<string, CardData> LoadItemDataCards(InspectorTabData tab, ItemData item);

      protected abstract IEnumerable<TabIndexData> GetAllValidTabItems();

      protected override object UniqueIdCreationLogic(object uniqueIdentifier)
          => uniqueIdentifier.ToString().ToSentenceCase();

      IEnumerable<TabIndexData> _filterItemTypes(IEnumerable<TabIndexData> input, string searchTerm, bool searchNamespace, bool abstractOrSplayedOnly) {
        if (string.IsNullOrWhiteSpace(searchTerm)) {
          if (!abstractOrSplayedOnly) {
            return input.OrderBy(t => t.SortKey);
          }
        } else {
          string normalizedSearchTerm = searchTerm.ToLower();
          Func<TabIndexData, bool> searchFilter = searchNamespace
            ? i => $"{i.Prefix}.{i.Name}".ToLower().Contains(normalizedSearchTerm)
            : i => i.Name.ToLower().Contains(normalizedSearchTerm);

          input = input
            .Where(searchFilter);
        }

        if (abstractOrSplayedOnly) {
          input = input
            .Where((Func<TabIndexData, bool>)(t => {
              var type = (System.Type.GetType(t.FullTypeName) as System.Type)
                ?? throw new Exception($"Type not found: {t.FullTypeName}");

              if (type.IsAbstract) {
                return true;
              }

              if (typeof(Archetype.ISplayed).IsAssignableFrom(type)) {
                if (!typeof(Archetype.ISplayedLazily).IsAssignableFrom(type)) {
                  return true;//_hasNoEnumValue(type);
                }
              }

              return false;
            }));
        }

        return input.OrderBy(t => t.SortKey);
      }

      /*bool _hasNoEnumValue(System.Type type) {
        if (type.GetCustomAttribute(typeof(Meep.Tech.Data.Configuration.Loader.Settings.DoNotBuildInInitialLoadAttribute)) == null
          && type.GetCustomAttribute(typeof(Meep.Tech.Data.Configuration.Loader.Settings.DoNotBuildThisOrChildrenInInitialLoadAttribute), true) == null
        ) {
          return false;
        }
        /*foreach (var splayType in type.GetAllInheritedGenericTypes(typeof(Archetype.IBuildOneForEach<,>))) {
          if (!typeof(Archetype.ISplayedLazily).IsAssignableFrom(splayType)) {
            MethodInfo getMethod
              = splayType.GetMethod("AssociatedEnum", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            if (getMethod() != null) {

            }
          }
        }*//*
        return true;
      }*/
    }
  }
}
