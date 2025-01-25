using Microsoft.Extensions.Logging;
using ReservaCanchas_Maui.Repositories;
using System.Runtime.Versioning;

namespace ReservaCanchas_Maui
{
    [SupportedOSPlatform("android")]
    [SupportedOSPlatform("ios")]
    [SupportedOSPlatform("windows")]
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

#if ANDROID || IOS || WINDOWS || MACCATALYST
            string dbPath1 = System.IO.Path.Combine(FileSystem.AppDataDirectory, "cancha.db3");
            string dbPath2 = System.IO.Path.Combine(FileSystem.AppDataDirectory, "complejo.db3");
            string dbPath3 = System.IO.Path.Combine(FileSystem.AppDataDirectory, "reserva.db3");
            string dbPath4 = System.IO.Path.Combine(FileSystem.AppDataDirectory, "usuario.db3");
#else
            string dbPath1 = string.Empty;
            string dbPath2 = string.Empty;
            string dbPath3 = string.Empty;
            string dbPath4 = string.Empty;
#endif


            builder.Services.AddSingleton<CanchaRepository>(s => ActivatorUtilities.CreateInstance<CanchaRepository>(s, dbPath1));

            builder.Services.AddSingleton<ComplejoRepository>(s => ActivatorUtilities.CreateInstance<ComplejoRepository>(s, dbPath2));

            builder.Services.AddSingleton<ReservaRepository>(s => ActivatorUtilities.CreateInstance<ReservaRepository>(s, dbPath3));

            builder.Services.AddSingleton<UsuarioRepository>(s => ActivatorUtilities.CreateInstance<UsuarioRepository>(s, dbPath4));

            builder.Services.AddSingleton<SQLServerRepository>();

            return builder.Build();
        }
    }
}
