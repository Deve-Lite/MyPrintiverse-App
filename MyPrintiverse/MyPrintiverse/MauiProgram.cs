

namespace MyPrintiverse;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var appInstance = MauiApp.CreateBuilder()
			.UseMauiApp<App>()
			.ConfigureServices()
			.ConfigureViews()
			.ConfigureViewModels()
			.ConfigureConfig($@"{AppDomain.CurrentDomain.BaseDirectory}/config.json", null)
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Raleway-Regular.ttf", "Raleway");
                fonts.AddFont("Oswald-Regular.ttf", "Oswald");
            })
			.Build();

		return appInstance;
	}
}
