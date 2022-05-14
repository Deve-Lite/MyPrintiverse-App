namespace MyPrintiverse.ViewModels
{
    public static class ConfigureViewModel
    {
        /// <summary>
        /// Extension method for builder to enable constructor injection.
        /// Each ViewModel must be initialized here.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
        {
            // template
            // builder.Services.AddSingleton<...ViewModel>();

            return builder;
        }
    }
}
