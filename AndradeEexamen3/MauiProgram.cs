using AndradeEexamen3.Services;
using Microsoft.Extensions.Logging;

namespace AndradeEexamen3
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "VehicleApp.db");
            builder.Services.AddSingleton(new VehiculoDatabase(dbPath));
            builder.Services.AddSingleton<ViewModels.VehiculoViewModel>();
            builder.Services.AddSingleton<Views.RegistroPage>();
            builder.Services.AddSingleton<Views.ListaVehiculosPage>();
            builder.Services.AddSingleton<Views.LogsPage>();

            return builder.Build();
        }
    }
}