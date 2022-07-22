using MyPrintiverse.Authorization.ChangePassword;
using MyPrintiverse.Authorization.ConfirmEmail;
using MyPrintiverse.Authorization.Login;
using MyPrintiverse.Authorization.RemindPassword;
using MyPrintiverse.Authorization.Settings;

namespace MyPrintiverse.Authorization;

public static class MauiAppExtensions
{
	public static MauiAppBuilder AuthorizationConfigureServices(this MauiAppBuilder @this)
	{
		@this.Services.AddScoped<IChangePasswordService, ChangePasswordService>();
		@this.Services.AddScoped<IConfirmEmailService, ConfirmEmailService>();
		@this.Services.AddScoped<ILoginService, LoginService>();
		@this.Services.AddScoped<IRemindPasswordService, RemindPasswordService>();
		@this.Services.AddScoped<ISettingsService, SettingsService>();

		return @this;
	}

	public static MauiAppBuilder AuthorizationConfigureViewModels(this MauiAppBuilder @this)
	{
		@this.Services.AddSingleton<ChangePasswordViewModel>();
		@this.Services.AddSingleton<ConfirmEmailViewModel>();
		@this.Services.AddSingleton<LoginViewModel>();
		@this.Services.AddSingleton<RemindPasswordViewModel>();
		@this.Services.AddSingleton<SettingsViewModel>();

		return @this;
	}

	public static MauiAppBuilder AuthorizationConfigureViews(this MauiAppBuilder @this)
	{
		@this.Services.AddSingleton<ChangePasswordView>();
		@this.Services.AddSingleton<ConfirmEmailView>();
		@this.Services.AddSingleton<LoginView>();
		@this.Services.AddSingleton<RemindPasswordView>();
		@this.Services.AddSingleton<SettingsView>();

		return @this;
	}
}
