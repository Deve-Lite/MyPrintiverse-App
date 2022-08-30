
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
                //Oswald
                /* 700 */ fonts.AddFont("Oswald-Bold.ttf", "OswaldBold");
				/* 600 */ fonts.AddFont("Oswald-SemiBold.ttf", "OswaldSemiBold");
                /* 500 */ fonts.AddFont("Oswald-Medium.ttf", "OswaldMedium");
				/* 400 */ fonts.AddFont("Oswald-Regular.ttf", "OswaldRegular");
                /* 300 */ fonts.AddFont("Oswald-Light.ttf", "OswaldLight");
                /* 200 */ fonts.AddFont("Oswald-ExtraLight.ttf", "OswaldExtraLight");
                //Raleway
                /* 900 */ fonts.AddFont("Raleway-Black.ttf", "RalewayBlack");
                /* 800 */ fonts.AddFont("Raleway-ExtraBold.ttf", "RalewayExtraBold");
                /* 700 */ fonts.AddFont("Raleway-Bold.ttf", "RalewayBold");
                /* 600 */ fonts.AddFont("Raleway-SemiBold.ttf", "RalewaySemiBold");
                /* 500 */ fonts.AddFont("Raleway-Medium.ttf", "RalewayMedium");
                /* 400 */ fonts.AddFont("Raleway-Regular.ttf", "RalewayRegular");
                /* 300 */ fonts.AddFont("Raleway-Light.ttf", "RalewayLight");
                /* 200 */ fonts.AddFont("Raleway-ExtraLight.ttf", "RalewayExtraLight");
                /* 100 */ fonts.AddFont("Raleway-Thin.ttf", "RalewayThin");
                //Raleway-Italic
                /* 900 */ fonts.AddFont("Raleway-BlackItalic.ttf", "RalewayBlackItalic");
                /* 800 */ fonts.AddFont("Raleway-ExtraBoldItalic.ttf", "RalewayExtraBoldItalic");
                /* 700 */ fonts.AddFont("Raleway-BoldItalic.ttf", "RalewayBoldItalic");
                /* 600 */ fonts.AddFont("Raleway-Italic.ttf", "RalewayItalic");
                /* 500 */ fonts.AddFont("Raleway-SemiBoldItalic.ttf", "RalewayThin");
                /* 400 */ fonts.AddFont("Raleway-MediumItalic.ttf", "RalewayMediumItalic");
                /* 300 */ fonts.AddFont("Raleway-LightItalic.ttf", "RalewayLightItalic");
                /* 200 */ fonts.AddFont("Raleway-ExtraLightItalic.ttf", "RalewayExtraLightItalic");
                /* 100 */ fonts.AddFont("Raleway-ThinItalic.ttf", "RalewayThinItalic");
            })
			.Build();

		return appInstance;
	}
}
