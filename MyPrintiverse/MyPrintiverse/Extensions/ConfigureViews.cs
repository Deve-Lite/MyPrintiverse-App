

using MyPrintiverse.AuthorizationModule;
using MyPrintiverse.FilamentsModule;
using MyPrintiverse.Templates.Test;

namespace MyPrintiverse.Extensions;

public static class ConfigureView
{
	/// <summary>
	/// Extension method for builder to enable constructor injection.
	/// Each View must be initialized here.
	/// </summary>
	/// <param name="builder"></param>
	/// <returns></returns>
	public static MauiAppBuilder ConfigureViews(this MauiAppBuilder builder)
	{
		// template
		// builder.Services.AddSingleton<...View>();

		builder.ConfigureAuthorizationViews();
        builder.ConfigureFilamentViews();
		builder.ConfigureTestViews();

        return builder;
	}
}