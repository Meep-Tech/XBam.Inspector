using Meep.Tech.Data;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Xbam.Inspector.Data {
  public partial class ArchetypeCardData : CardData {

    [AutoBuild, Required, NotNull]
    public Archetype ForArchetype {
      get;
      private set;
    }

    ArchetypeCardData() : base() { }
  }
}