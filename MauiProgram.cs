using Meep.Tech.Data;
using Meep.Tech.Data.Configuration;
using Meep.Tech.Data.IO;
using Xbam.Inspector.Data;

namespace Xbam.Inspector;

public static class MauiProgram {

    public static Universe Universe {
        get;
        private set;
    }

    public static MauiApp CreateMauiApp() {
        _initializeXbam(FileSystem.Current.AppDataDirectory);

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

    static void _initializeXbam(string rootAppDirectory) {
        //// Configure Settings
        /// Loader settings
        Loader.Settings settings = new() {
#if DEBUG
            FatalOnCannotInitializeType = true,
#endif
            PreLoadAssemblies = new() {
                typeof(MauiProgram).Assembly,
                typeof(Meep.Tech.Data.Examples.AutoBuilder.Animal).Assembly
            }
        };

        Loader loader = new(settings);

        /// porter settings
        Universe = new Universe(loader, "XBam.Inspector");
        Universe.SetExtraContext(
            new FullModelCoverageModImportContext(
                new(
                    Universe,
                    rootAppDirectory,
                    null,
                    null
        )));

        /// Load Archetypes
        loader.Initialize(Universe);
    }
}
