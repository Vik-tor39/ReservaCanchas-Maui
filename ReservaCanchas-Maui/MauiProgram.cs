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
            string dbPathCancha = FileAccessHelper.GetLocalFilePath("cancha.db3");
            string dbPathUsuario = FileAccessHelper.GetLocalFilePath("usuario.db3");
            string dbPathComplejo = FileAccessHelper.GetLocalFilePath("complejo.db3");
            string dbPathReserva = FileAccessHelper.GetLocalFilePath("reserva.db3");

            if (File.Exists(dbPathCancha))
            {
                builder.Services.AddSingleton<CanchaRepository>(s => ActivatorUtilities.CreateInstance<CanchaRepository>(s, dbPathCancha));
            }

            if (File.Exists(dbPathComplejo))
            {
                builder.Services.AddSingleton<ComplejoRepository>(s => ActivatorUtilities.CreateInstance<ComplejoRepository>(s, dbPathComplejo));
            }

            if (File.Exists(dbPathReserva))
            {
                builder.Services.AddSingleton<ReservaRepository>(s => ActivatorUtilities.CreateInstance<ReservaRepository>(s, dbPathReserva));
            }

            if (File.Exists(dbPathUsuario))
            {
                builder.Services.AddSingleton<UsuarioRepository>(s => ActivatorUtilities.CreateInstance<UsuarioRepository>(s, dbPathUsuario));
            }

            return builder.Build();
        }
    }
}
