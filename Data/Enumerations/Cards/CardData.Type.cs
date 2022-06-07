using Meep.Tech.Data;

namespace Xbam.Inspector.Data {
    public partial class CardData {
        public class Type : Enumeration<Type> {

            /// <summary>
            /// This is a card with info about the c# code itself, like fields and methods
            /// </summary>
            public static Type CSharpCode {
                get;
            } = new(nameof(CSharpCode), "deepskyblue", "royalblue");

            /// <summary>
            /// This is a card with XBam specific information such as traits, attributes, and base types.
            /// </summary>
            public static Type XBamMetadata {
                get;
            } = new(nameof(XBamMetadata), "ForestGreen", "DarkGreen");

            /// <summary>
            /// This card represents a model data component.
            /// </summary>
            public static Type ModelComponent {
                get;
            } = new(nameof(ModelComponent), "MediumSlateBlue", "SlateBlue");

            /// <summary>
            /// This card represents an archetype data component.
            /// </summary>
            public static Type ArchetypeComponent {
                get;
            } = new(nameof(ArchetypeComponent), "Crimson", "firebrick");

            public string ExpandedColor { get; }
            public string CollapsedColor { get; }

            protected Type(string name, string expandedColor, string collapsedColor)
                : base(name) {
                ExpandedColor = expandedColor;
                CollapsedColor = collapsedColor;
            }
        }
    }
}