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
		var configInstance = ConfigService<Config>.GetInstance(filePath);
		builder.Services.AddSingleton(configInstance);

		return builder;
	}
}