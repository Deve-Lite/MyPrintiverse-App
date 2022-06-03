using MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentsPage;

namespace MyPrintiverse.Extensions
{
    public static class ConfigureView
    {
        /// <summary>
        /// Extension method for builder to enable constructor injection.
        /// Each View must be initialized here.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static MauiAppBuilder ConfigureViews(this MauiAppBuilder builder)
        {
            // template
            // builder.Services.AddSingleton<...View>();

            builder.Services.AddSingleton<FilamentsView>();
            builder.Services.AddSingleton<FilamentView>();
            builder.Services.AddSingleton<AddFilamentView>();
            builder.Services.AddSingleton<EditFilamentView>();


            return builder;
        }
    }
}
