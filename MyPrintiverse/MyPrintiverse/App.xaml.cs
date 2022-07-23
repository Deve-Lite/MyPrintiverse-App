

using MyPrintiverse.FilamentsModule;
using MyPrintiverse.Templates.Test;

namespace MyPrintiverse;

public partial class App : Application
{
	public App()
	{
        RegisterRoutes();

        InitializeComponent();

    }

    /// <summary>
    /// Register routes for routing system.
    /// Each view should be registered here.
    /// </summary>
    private void RegisterRoutes()
    {
        // template
        // Routing.RegisterRoute(nameof(...View), typeof(...View));

        FilamentRouteConfig.RegisterFilamentRoutes();
        TestRouteConfig.RegisterTestRoutes();
    }

    // TODO 
    // back button behaviour in PhoneShell (Shell will be divided into desktop and mobile for easier management)
}
