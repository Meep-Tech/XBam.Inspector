﻿using Meep.Tech.Data;
using Meep.Tech.Data.Reflection;
using Meep.Tech.Data.Utility;

namespace Xbam.Inspector.Data {
    public partial class TabData {
        public abstract partial class Type : Enumeration<Type> {
            public class ModelTypeFamilyTab : Type {
                public static ModelTypeFamilyTab Id { get; }
                    = new();
                ModelTypeFamilyTab()
                    : base(nameof(ModelTypeFamilyTab)) { }
            }
            public class ModelTypeInstancesTab : Type {
                public static ModelTypeInstancesTab Id { get; }
                    = new();
                ModelTypeInstancesTab()
                    : base(nameof(ModelTypeInstancesTab)) { }
            }
            public class ComponentsFamilyTab : Type {
                public static ComponentsFamilyTab Id { get; }
                    = new();
                ComponentsFamilyTab()
                    : base(nameof(ComponentsFamilyTab)) { }
            }

            protected Type(string uniqueIdentifier)
                : base(uniqueIdentifier) { }

            public IEnumerable<TabTypeData> GetTabItemTypes(string optionalSearchTerm = null, bool searchNamespace = false)
                => _filterItemTypes(GetAllValidTabItems(), optionalSearchTerm?.ToLower(), searchNamespace);

            protected virtual IEnumerable<TabTypeData> GetAllValidTabItems() => new TabTypeData[] {
                ("Test.Type", "Testing.Prefix"),
                ("Test.Type2", "Testing.Prefix"),
                ("Test.Type3", "Testing.Prefix"),
                ("Test.Type4", "Testing.Prefix"),
                ("Test.Type5", "Testing.Prefix"),
                ("Test.Type.Aple", "Testing.Prefix"),
                ("Test.Typ9", "Testing.Prefix"),
                ("Test.Ty9pe", "Testing.Prefix"),
                ("Test.Ty9pe2", "Testing.Prefix"),
                ("Test.Ty9pe3", "Testing.Prefix"),
                ("Test.Typ9e4", "Testing.Prefix"),
                ("Test.Typ9e5", "Testing.Prefix"),
                ("Test.Ty9pe.Aple", "Testing.Prefix"),
                ("Test.T9yp", "Testing.Prefix"),
                ("Test.Ty9pe", "Testing.Prefix"),
                ("Test.9Type2", "Testing.Prefix"),
                ("Te9st.Type3", "Testing.Prefix"),
                ("Test.9Type4", "Testing.Prefix"),
                ("Tes6t.Type5", "Testing.Prefix"),
                ("Tesut.Type.Aple", "Testing.Prefix"),
                ("Test.Tuyp", "Testing.Prefix"),
                ("Test.uType", "Testing.Prefix"),
                ("Teust.Type2", "Testing.Prefix"),
                ("Test.Tyupe3", "Testing.Prefix"),
                ("Tuest.Tyupe4", "Testing.Prefix"),
                ("Tjest.Type5", "Testing.Prefix"),
                ("Tesht.Type.Aple", "Testing.Other"),
                ("Test.Tykp", "Testing.Prefix"),
                ("TepstItem", "Testing.Prefix")
            };

            protected override object UniqueIdCreationLogic(object uniqueIdentifier)
                => uniqueIdentifier.ToString().ToSentenceCase();

            IEnumerable<TabTypeData> _filterItemTypes(IEnumerable<TabTypeData> input, string searchTerm, bool searchNamespace) 
              => (searchTerm is null
                ? input
                : searchNamespace
                  ? input
                    .Where(i => $"{i.Prefix}.{i.Name}".ToLower().Contains(searchTerm))
                  : input
                    .Where(i => i.Name.ToLower().Contains(searchTerm)))
                .OrderBy(t => t.Name);
        }
    }
}