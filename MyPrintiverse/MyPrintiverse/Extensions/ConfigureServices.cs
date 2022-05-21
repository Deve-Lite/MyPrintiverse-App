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
            /* Implementation */


            return builder;
        }
    }
}
