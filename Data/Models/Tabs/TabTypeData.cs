using Meep.Tech.Data.Reflection;

namespace Xbam.Inspector.Data {
    public record struct TabTypeData(string Name, string Prefix, bool IsAbstract = false) {
        string _shortName = null;
        string _longNamePrefix = null;
        string _shortNamePrefix = null;
        string _longWithoutShortNamePrefix = null;

        public string ShortName
            => _shortName ??= Name.Split('.').Last().Split('+').Last();

        public string LongNamePrefix
            => _longNamePrefix ??= Name.Remove(Name.Length - ShortName.Length, ShortName.Length);

        public string ShortNamePrefix
            => _shortNamePrefix ??= LongNamePrefix.Split('.').Last();

        public string LongNamePrefixWithoutShortNamePrefix
            => _longWithoutShortNamePrefix ??= LongNamePrefix.Remove(startIndex: LongNamePrefix.Length - ShortNamePrefix.Length, ShortNamePrefix.Length);

        public static implicit operator (string type, string prefix)(TabTypeData value) {
            return (value.Name, value.Prefix);
        }

        public static implicit operator (string type, string prefix, bool isAbstract)(TabTypeData value) {
            return (value.Name, value.Prefix, value.IsAbstract);
        }

        public static implicit operator TabTypeData((string type, string prefix) value) {
            return new TabTypeData(value.type, value.prefix);
        }

        public static implicit operator TabTypeData((string type, string prefix, bool isAbstract) value) {
            return new TabTypeData(value.type, value.prefix, value.isAbstract);
        }

        public TabTypeData(Type t) : this(default, default, default) {
            Name = t.ToFullHumanReadableNameString(false);
            Prefix = t.Namespace;
            IsAbstract = t.IsAbstract;
        }
    }
}
