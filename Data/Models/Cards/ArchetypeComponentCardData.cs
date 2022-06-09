using Meep.Tech.Data;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Xbam.Inspector.Data {
    public partial class ArchetypeComponentCardData : CardData {

    [AutoBuild, Required, NotNull]
    public Archetype.IComponent Component { get; private set; }
  }
}