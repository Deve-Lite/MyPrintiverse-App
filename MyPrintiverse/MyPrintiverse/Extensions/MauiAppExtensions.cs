using Microsoft.Extensions.DependencyInjection;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Extensions;

public static class MauiAppExtensions
{
	/// <summary>
	/// MAUI extension for initialization of config.
	/// </summary>
	/// <param name="builder"></param>
	/// <param name="filePath"></param>
	/// <param name="logger"></param>
	/// <returns></returns>
	public static MauiAppBuilder ConfigureConfig(this MauiAppBuilder builder, string filePath, ILogger logger)
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