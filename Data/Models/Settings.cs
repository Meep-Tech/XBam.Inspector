using Meep.Tech.Data;
using Meep.Tech.Data.Configuration;
using System.ComponentModel;

namespace Xbam.Inspector.Data {

	/// <summary>
	/// The Base Model for all Settingss
	/// </summary>
	public class Settings {

    /// <summary>
    /// The folder containing the /data/ folder to import from..
    /// </summary>
    [Description("The folder containing the /data/ folder to load mods and plugins from.")]
    [AutoBuild(IsRequiredAsAParameter = true, NotNull = true)]
		public string ParentDataFolder {
			get;
		  set;
		}

		[AutoBuild]
		[Description("If true, the types from Meep.Tech.Data.Examples will be included in loading. If false they will not.")]
		public bool IncludeExampleXBamTypes {
			get;
			set;
		}

		[AutoBuild(NotNull = true)]
    [Description("Json version of Loader.Settings used to initialize XBam.")]
    public Loader.Settings XBamLoaderSettings {
			get;
		  set;
		} = new();
	}
}
