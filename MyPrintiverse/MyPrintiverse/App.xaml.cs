using MyPrintiverse.Admin;
using MyPrintiverse.Authorization;
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
    private static void RegisterRoutes()
    {
        FilamentRouteConfig.RegisterFilamentRoutes();
        TestRouteConfig.RegisterTestRoutes();
        
        new AdminRouteRegister()
	        .RegisterRoutes();

        new AuthorizationRouteRegister()
	        .RegisterRoutes();
	}
}
