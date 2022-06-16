using Meep.Tech.Data;
using Meep.Tech.Data.Configuration;
using Meep.Tech.Data.IO;
using Newtonsoft.Json;
using Xbam.Inspector.Data;

namespace Xbam.Inspector;

public static class MauiProgram {
	public const string InspectorConfigName = "inspector.config";
  public static string InspectorConfigFileLocation 
    = Path.Combine(
        Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
        InspectorConfigName
      );

  public static Settings Options {
    get;
    set;
  }

  public static Universe Universe {
    get;
    private set;
  }

  public static MauiApp CreateMauiApp() {
    _loadOptions();
    _initializeXbam(FileSystem.Current.AppDataDirectory);
    Options ??= new Settings {
      ParentDataFolder = FileSystem.Current.AppDataDirectory,
      XBamLoaderSettings = Universe.Loader.Options
    };

    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      .ConfigureFonts(fonts => {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
      });

    builder.Services.AddMauiBlazorWebView();
#if DEBUG
    builder.Services.AddBlazorWebViewDeveloperTools();
#endif

    builder.Services.AddSingleton<WeatherForecastService>();

    return builder.Build();
  }

  static void _loadOptions() {
    if (File.Exists(InspectorConfigFileLocation)) {
      try {
        Options = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(InspectorConfigFileLocation));
			} catch {
        Options = null;
			}
    }
  }

  static void _initializeXbam(string rootAppDirectory) {
    //// Configure Settings
    /// Loader settings
    Loader.Settings settings 
      = Options?.XBamLoaderSettings 
        ?? new();

    settings.PreLoadAssemblies.Add(
          typeof(MauiProgram).Assembly);

    if(Options?.IncludeExampleXBamTypes ?? false) {
      settings.PreLoadAssemblies.Add(
          typeof(Meep.Tech.Data.Examples.AutoBuilder.Animal).Assembly);
    } else {
      settings.IgnoredAssemblies.Add(
          typeof(Meep.Tech.Data.Examples.AutoBuilder.Animal).Assembly);
		}

    Loader loader = new(settings);

    /// porter settings
    Universe = new Universe(loader, "XBam.Inspector");
    Universe.AddModImportContext(rootAppDirectory);
    string rootFolder = Universe.GetModData().RootModsFolder;
    if (Directory.Exists(rootFolder)) {
      Universe.AddAllModPluginAssemblies();
    }

    /// Load Archetypes
    loader.Initialize(Universe);
  }
}
