using Meep.Tech.Data;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Xbam.Inspector.Data {
  public partial class CardData : Model<CardData, CardData.Type> {

    [AutoBuild, Required, NotNull]
    public string Key { get; private set; }

    [AutoBuild]
    public bool IsExpanded { get; internal set; } = true;

    internal protected CardData() { }
  }
}