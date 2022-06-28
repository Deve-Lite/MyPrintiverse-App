namespace MyPrintiverse;

public static class MauiAppExtensions
{
	public static MauiAppBuilder InitConfig(this MauiAppBuilder builder, string filePath, ILogger logger)
	{
		var configInstance = ConfigService<Config>.GetInstance(filePath);
		builder.Services.AddSingleton(configInstance);

		return builder;
	}
}