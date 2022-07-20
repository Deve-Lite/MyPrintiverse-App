

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
			.ConfigureConfig($@"{AppDomain.CurrentDomain.BaseDirectory}\config.json", null)
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Raleway-VariableFont", "Raleway");
                fonts.AddFont("Oswald-VariableFont.ttf", "Oswald");
            })
			.Build();

		return appInstance;
	}
}
