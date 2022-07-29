using MyPrintiverse.AuthorizationModule.ChangePasswordPage;
using MyPrintiverse.AuthorizationModule.ConfirmEmailPage;
using MyPrintiverse.AuthorizationModule.LoginPage;
using MyPrintiverse.AuthorizationModule.RemindPasswordPage;
using MyPrintiverse.AuthorizationModule.SettingsPage;
using MyPrintiverse.Core.Collections;

namespace MyPrintiverse.AuthorizationModule;

public static class AuthorizationModule
{
	public static void AuthorizationConfigureRoutes()
	{
		var routes = new Dictionary<string, Type>
		{
			{ nameof(ChangePasswordView), typeof(ChangePasswordView) },
			{ nameof(ConfirmEmailView), typeof(ConfirmEmailView) },
			{ nameof(LoginView), typeof(LoginView) },
			{ nameof(RemindPasswordView), typeof(RemindPasswordView) },
			{ nameof(SettingsView), typeof(SettingsView) },
		};

		routes.ForEach(pair =>
		{
			Routing.RegisterRoute(pair.Key, pair.Value);
		});
	}
}