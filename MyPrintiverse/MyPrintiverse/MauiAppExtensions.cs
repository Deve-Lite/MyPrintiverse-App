using MyPrintiverse.Admin;
using MyPrintiverse.Authorization;
using MyPrintiverse.FilamentsModule;
using MyPrintiverse.Templates.Test;
using MyPrintiverse.Core.Http;
using MyPrintiverse.Tools;

namespace MyPrintiverse;

public static class MauiAppExtensions
{
    /// <summary>
    /// MAUI extension for initialization of config.
    /// </summary>
    /// <param name="builder">Extension instance.</param>
    /// <param name="configFilePath">Config file path.</param>
    /// <returns></returns>
    public static MauiAppBuilder ConfigureDI(this MauiAppBuilder builder, string configFilePath)
    {
		var assembly = Assembly.GetExecutingAssembly();

		var configInstance = new ConfigService<Config>(assembly, configFilePath);
		builder.Services.AddSingleton<IConfigService<Config>>(configInstance);

		var sessionInstance = new Session(configInstance);
        builder.Services.AddSingleton<ISession>(sessionInstance);

        var messageInstance = new MessageService();
        builder.Services.AddSingleton<IMessageService>(messageInstance);

        var httpService = new HttpService(configInstance);
		builder.Services.AddSingleton<IHttpService>(httpService);

        builder.Services.AddSingleton<IToast, ToastService>();

        return builder;
    }

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

        builder.AuthorizationConfigureViewModels();
        builder.ConfigureFilamentViewModels();
        builder.ConfigureTestViewsModels();
        builder.AdminConfigureViewModels();

        return builder;
    }

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

        builder.AuthorizationConfigureViews();
        builder.ConfigureFilamentViews();
        builder.ConfigureTestViews();
        builder.AdminConfigureViews();

        return builder;
    }

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

        builder.AuthorizationConfigureServices();
        builder.ConfigureFilamentServices();
        builder.AdminConfigureServices();

		return builder;
    }
}