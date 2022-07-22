
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
			.ConfigureDI("config.json")
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Oswald-Regular.ttf", "Oswald");
                fonts.AddFont("Raleway-Black.ttf", "RalewayBlack");
                fonts.AddFont("Raleway-ExtraBold.ttf", "RalewayExtraBold");
                fonts.AddFont("Raleway-Bold.ttf", "RalewayBold");
                fonts.AddFont("Raleway-SemiBold.ttf", "RalewaySemiBold");
                fonts.AddFont("Raleway-Regular.ttf", "RalewayRegular");
                fonts.AddFont("Raleway-Medium.ttf", "RalewayMedium");
                fonts.AddFont("Raleway-Thin.ttf", "RalewayThin");
                fonts.AddFont("Raleway-Light.ttf", "RalewayLight");
                fonts.AddFont("Raleway-BlackItalic.ttf", "RalewayBlackItalic");
                fonts.AddFont("Raleway-ExtraLight.ttf", "RalewayExtraLight");
                fonts.AddFont("Raleway-ExtraBoldItalic-.ttf", "RalewayExtraBoldItalic");
                fonts.AddFont("Raleway-BoldItalic.ttf", "RalewayBoldItalic");
                fonts.AddFont("Raleway-SemiBoldItalic.ttf", "RalewayThin");
                fonts.AddFont("Raleway-Italic.ttf", "RalewayItalic");
                fonts.AddFont("Raleway-MediumItalic.ttf", "RalewayMediumItalic");
                fonts.AddFont("Raleway-ThinItalic.ttf", "RalewayThinItalic");
                fonts.AddFont("Raleway-LightItalic.ttf", "RalewayLightItalic");
                fonts.AddFont("Raleway-ExtraLightItalic.ttf", "RalewayExtraLightItalic");
            })
			.Build();

		return appInstance;
	}
}
