using Meep.Tech.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Xbam.Inspector.Shared.Components.Cards;

namespace Xbam.Inspector.Data {
  public partial class CardData : Model<CardData, CardData.Type> {

    [AutoBuild, Required, NotNull]
    public string Key { get; private set; }

    [AutoBuild, DefaultValue(true)]
    public bool IsExpanded { get; internal set; }

    [AutoBuild(DefaultArchetypePropertyName = nameof(Type.DefaultCardHeight)), DefaultValue(Card.Heights.Middle)]
    public Card.Heights Height { get; internal protected set; }

    protected CardData() { }
  }
}