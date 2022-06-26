namespace MyPrintiverse;

public static class MauiAppExtensions
{
	public static MauiAppBuilder InitConfig(this MauiAppBuilder mauiApp, string filePath, ILogger logger)
	{
		ConfigService<Config>.Initialize(filePath);

		return mauiApp;
	}
}