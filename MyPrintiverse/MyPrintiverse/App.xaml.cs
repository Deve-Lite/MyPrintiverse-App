﻿
using MyPrintiverse.Admin;
using MyPrintiverse.Authorization;
using MyPrintiverse.FilamentsModule;
using MyPrintiverse.Templates.Test;
using MyPrintiverse.Tools;

namespace MyPrintiverse;

public partial class App : Application
{
    public App(IToast toast)
    {
        RegisterRoutes();

        InitializeComponent();

        if (DeviceIdiom.Phone == DeviceInfo.Idiom)
            MainPage = new MobileShell(toast);
        else
            MainPage = new DesktopShell();
    }

    /// <summary>
    /// Register routes for routing system.
    /// Each view should be registered here.
    /// </summary>
    private static void RegisterRoutes()
    {
        new FilamentRouteConfig()
            .RegisterRoutes();

        new AuthorizationRouteRegister()
	        .RegisterRoutes();


        #region Dev
        new TestRouteConfig()
            .RegisterRoutes();

        new AdminRouteRegister()
            .RegisterRoutes();

        #endregion
    }

}
