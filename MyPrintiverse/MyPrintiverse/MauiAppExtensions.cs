using MyPrintiverse.AuthorizationModule;
using MyPrintiverse.FilamentsModule;
using MyPrintiverse.Templates.Test;
using MyPrintiverse.Tools;

namespace MyPrintiverse;

public static class MauiAppExtensions
{
    /// <summary>
    /// MAUI extension for initialization of config.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static MauiAppBuilder ConfigureConfig(this MauiAppBuilder builder, string filePath)
    {
        var configInstance = new ConfigService<Config>(filePath);
        builder.Services.AddSingleton<IConfigService<Config>>(configInstance);
        var session = new Session(configInstance);
        builder.Services.AddSingleton<ISession>(session);
        var loggerInst = new Logger();
        builder.Services.AddSingleton<ILogger>(loggerInst);

        var messageService = new MessageService();
        builder.Services.AddSingleton<IMessageService>(messageService);
        builder.Services.AddSingleton<MessageService>();

        var settingsService = new SettingsService();
        builder.Services.AddSingleton<ISettingsService>(settingsService);

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

        return builder;
    }
}


// Do usuniecia zrobione tylko po to zeby nie wyrzucało błędu.
public class Logger : ILogger
{
    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return false;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {

    }
}