

using MyPrintiverse.FilamentsModule;

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
            return builder.ConfigureFilamentViews();
        }
    }
}
