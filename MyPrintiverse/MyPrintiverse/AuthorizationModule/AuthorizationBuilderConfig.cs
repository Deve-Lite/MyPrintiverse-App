using MyPrintiverse.AuthorizationModule.ChangePasswordPage;
using MyPrintiverse.AuthorizationModule.ConfirmEmailPage;
using MyPrintiverse.AuthorizationModule.LoginPage;
using MyPrintiverse.AuthorizationModule.RemindPasswordPage;
using MyPrintiverse.AuthorizationModule.SettingsPage;

namespace MyPrintiverse.AuthorizationModule;

public static class AuthorizationBuilderConfig
{
	public static MauiAppBuilder ConfigureAuthorizationServices(this MauiAppBuilder @this)
	{
		@this.Services.AddSingleton<ChangePasswordService>();
		@this.Services.AddSingleton<ConfirmEmailService>();
		@this.Services.AddSingleton<LoginService>();
		@this.Services.AddSingleton<RemindPasswordService>();
		@this.Services.AddSingleton<SettingsService>();

		return @this;
	}

	public static MauiAppBuilder ConfigureAuthorizationViewModels(this MauiAppBuilder @this)
	{
		@this.Services.AddSingleton<ChangePasswordViewModel>();
		@this.Services.AddSingleton<ConfirmEmailViewModel>();
		@this.Services.AddSingleton<LoginViewModel>();
		@this.Services.AddSingleton<RemindPasswordViewModel>();
		@this.Services.AddSingleton<SettingsViewModel>();

		return @this;
	}

	public static MauiAppBuilder ConfigureAuthorizationViews(this MauiAppBuilder @this)
	{
		@this.Services.AddSingleton<ChangePasswordView>();
		@this.Services.AddSingleton<ConfirmEmailView>();
		@this.Services.AddSingleton<LoginView>();
		@this.Services.AddSingleton<RemindPasswordView>();
		@this.Services.AddSingleton<SettingsView>();

		return @this;
	}
}