using MyPrintiverse.FilamentsModule;
using MyPrintiverse.FilamentsModule.Filaments;
using MyPrintiverse.FilamentsModule.Filaments.Services;

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
            return builder.ConfigureFilamentServices();
        }
    }
}
