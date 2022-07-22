using MyPrintiverse.Authorization.ChangePassword;
using MyPrintiverse.Authorization.ConfirmEmail;
using MyPrintiverse.Authorization.Login;
using MyPrintiverse.Authorization.RemindPassword;
using MyPrintiverse.Authorization.Settings;
using MyPrintiverse.Authorization.SignIn;

namespace MyPrintiverse.Authorization;

public class AuthorizationRouteRegister : RouteRegister
{
	public override void RegisterRoutes()
	{
		var routes = new List<Type>()
		{
			typeof(ChangePasswordView),
			typeof(ConfirmEmailView),
			typeof(LoginView),
			typeof(RemindPasswordView),
			typeof(SettingsView),
			typeof(SignInView)
		};

		Register(routes);
	}
}