

using MyPrintiverse.FilamentsModule;

namespace MyPrintiverse;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        // Tutaj ewentualnie opcja rozbicia na 2 pliki AppShell osobno Dekstop osobno Mobile.
        //if (DeviceInfo.Idiom == DeviceIdiom.Phone)
           // Shell.Current.CurrentItem = PhoneTabs;

        RegisterRoutes();
    }

    /// <summary>
    /// Register routs for routing system.
    /// Each view should be registered here.
    /// </summary>
    private void RegisterRoutes()
    {
        // template
        // Routing.RegisterRoute(nameof(...View), typeof(...View));

        FilamentRouteConfig.RegisterFilamentRoutes();
    }
}
