using Meep.Tech.Data;
using Meep.Tech.Data.Reflection;

namespace Xbam.Inspector.Data {
    public record struct TabIndexData(string FullTypeName, string Name, string Prefix, bool IsAbstract = false) {
        string _shortName = null;
        string _longNamePrefix = null;
        string _shortNamePrefix = null;
        string _longWithoutShortNamePrefix = null;

        public string ShortName {
            get {
                if (_shortName is null) {
                    _shortName = Name.Split('.').Last().Split('+').Last();
                    if (_shortName == "Identity") {
                        _shortNamePrefix = LongNamePrefixWithoutShortNamePrefix.Split(',').Last().Trim(',','<','>');
                    }
                }

                return _shortName;
            }
        }

        public string LongNamePrefix
            => _longNamePrefix ??= Name.Remove(Name.Length - ShortName.Length, ShortName.Length);

        public string ShortNamePrefix
            => _shortNamePrefix ??= LongNamePrefix.Split('.').Last();

        public string LongNamePrefixWithoutShortNamePrefix {
            get {
                if (_longWithoutShortNamePrefix is null) {
                    _longWithoutShortNamePrefix = LongNamePrefix.Remove(startIndex: LongNamePrefix.Length - ShortNamePrefix.Length, ShortNamePrefix.Length);

                    if (_shortName == "BuilderFactory") {
                        if (!string.IsNullOrWhiteSpace(_longWithoutShortNamePrefix)) {
                            _shortNamePrefix = _longWithoutShortNamePrefix;
                            _longWithoutShortNamePrefix = "";
                        }
                    }
                }

                return _longWithoutShortNamePrefix;
            }
        }

        /// <summary>
        /// A unique key for this.
        /// </summary>
        public string Key 
            => Prefix
                + (string.IsNullOrWhiteSpace(Prefix) ? "" : ".")
                + Name ?? throw new ArgumentNullException(nameof(Name));

        /// <summary>
        /// A NON Unique key for alphabetical sort order placement
        /// </summary>
        public string SortKey {
            get {
                if (ShortName == "Identity") {
                    if (ShortNamePrefix.StartsWith("IComponent<")) {
                        return ShortNamePrefix.Split("<")[1].Split('>')[0];
                    }
                    else if (Name.StartsWith(nameof(Archetype) + "<")) {
                        return ShortNamePrefix;
                    } else
                        return Name;
                }
                else if (Name.StartsWith("IComponent<")) {
                    return Name.Split("<")[1].Split('>')[0];
                } else if (Name.StartsWith(nameof(Archetype) + "<")) {
                    return ShortNamePrefix;
                }
                else return Name;
            }
        }

        // TODO: remove after testing
        public static implicit operator TabIndexData((string type, string prefix) value) {
            return new TabIndexData(value.prefix + "." + value.type,  value.type, value.prefix);
        }

        // TODO: remove after testing
        public static implicit operator TabIndexData((string type, string prefix, bool isAbstract) value) {
            return new TabIndexData(value.prefix + "." + value.type, value.type, value.prefix, value.isAbstract);
        }

        public TabIndexData(Type t) 
            : this(
                  t.AssemblyQualifiedName,
                  t.ToFullHumanReadableNameString(false),
                  t.Namespace,
                  t.IsAbstract
            ) {}
    }
}
