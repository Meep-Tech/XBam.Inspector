using Meep.Tech.Data;
using Microsoft.AspNetCore.Components;
using Xbam.Inspector.Shared.Components.Cards;
using Xbam.Inspector.Shared.Components.Cards.Content;

namespace Xbam.Inspector.Data {
  public partial class CardData {
    public abstract class Type : Archetype<CardData, Type>.WithDefaultParamBasedModelBuilders {

      /// <summary>
      /// This is a card with info about the c# code itself, like fields and methods
      /// </summary>
      public abstract class CSharpCode : Type {
        protected CSharpCode(Identity identity, string expandedColor = "deepskyblue", string collapsedColor = "royalblue") 
          : base(identity, expandedColor, collapsedColor) {}
      }

      /// <summary>
      /// This is a card with XBam specific information such as traits, attributes, and base types.
      /// </summary>
      public abstract class XBamMetadata : Type {
        protected XBamMetadata(Identity identity, string expandedColor = "ForestGreen", string collapsedColor = "DarkGreen") 
          : base(identity, expandedColor, collapsedColor) {}
      }

      /// <summary>
      /// This card represents a model data component.
      /// </summary>
      public abstract class ModelComponent : Type {
        protected ModelComponent(Identity identity, string expandedColor = "MediumSlateBlue", string collapsedColor = "SlateBlue") 
          : base(identity, expandedColor, collapsedColor) {}
      }

      /// <summary>
      /// This card represents an archetype data component.
      /// </summary>
      public abstract class ArchetypeComponent : Type {
        protected ArchetypeComponent(Identity identity, string expandedColor = "Crimson", string collapsedColor = "firebrick")
          : base(identity, expandedColor, collapsedColor) { }
      }


      public string ExpandedColor { get; }
      public string CollapsedColor { get; }

      /// <summary>
      /// The component type used to render the card contents.
      /// </summary>
      public abstract System.Type CardComponentType { get; }

      /// <summary>
      /// Used to render the card contents given the data.
      /// </summary>
      public Func<CardData, RenderFragment> RenderCard
        => card => new(builder => {
          builder.OpenComponent(1, CardComponentType);
          builder.AddAttribute(1, nameof(DataCardContent.State), card);
          builder.CloseComponent();
        });


      protected Type(Identity identity, string expandedColor, string collapsedColor)
          : base(identity) {
        ExpandedColor = expandedColor;
        CollapsedColor = collapsedColor;
      }
    }
  }
}