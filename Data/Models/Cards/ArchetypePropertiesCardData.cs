using Meep.Tech.Data;
using System.ComponentModel;
using Xbam.Inspector.Pages.ItemPannel.Cards.Content;

namespace Xbam.Inspector.Data {

    public partial class ArchetypePropertiesCardData : ArchetypeCardData {

    [AutoBuild, DefaultValue(ArchetypePropertiesDataCard.AccessLevel.PublicAndProtected)]
    public ArchetypePropertiesDataCard.AccessLevel SearchAccessLevel { get; set; }

    [AutoBuild, DefaultValue("")]
    public string SearchTerm { get; set; }

    [AutoBuild, DefaultValue(true)]
    public bool SearchOverrideableOnly { get; set; }

    [AutoBuild, DefaultValue(false)]
    public bool SearchDeclaredOnly { get; set; }
  }
}