

namespace MyPrintiverse.Extensions
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Extension method for builder to enable constructor injection.
        /// Each Service must be initialized here.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
        {
            // Template
            // builder.Services.TryAddTransient<...Service>();
            // builder.Services.AddSingleton<...Service>();

            /* Filament Services */
            builder.Services.AddSingleton<FilamentDeviceService>();
            builder.Services.AddSingleton<SpoolDeviceService>();
            builder.Services.AddSingleton<PrintDeviceService>();
            builder.Services.AddSingleton<TypeDeviceService>();




            return builder;
        }
    }
}
