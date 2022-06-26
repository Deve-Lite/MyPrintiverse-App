namespace MyPrintiverse;

public static class MauiAppExtensions
{
	public static MauiAppBuilder InitConfig(this MauiAppBuilder mauiApp, string filePath, ILogger logger)
	{
		var configInstance = ConfigService<Config>.GetInstance(filePath);
		// dosprawdzenia
		mauiApp.Services.AddSingleton(configInstance);

		return mauiApp;
	}
}