
namespace MyPrintiverse.Admin
{
	public static class AdminPanelBuilderConfig
	{
		public static MauiAppBuilder AdminConfigureServices(this MauiAppBuilder @this)
		{
			@this.Services.AddScoped<IAdminService, AdminService>();
		
			return @this;
		}

		public static MauiAppBuilder AdminConfigureViewModels(this MauiAppBuilder @this)
		{
			@this.Services.AddScoped<AdminViewModel>();

			return @this;
		}

		public static MauiAppBuilder AdminConfigureViews(this MauiAppBuilder @this)
		{
			@this.Services.AddScoped<AdminView>();

			return @this;
		}
	}
}
