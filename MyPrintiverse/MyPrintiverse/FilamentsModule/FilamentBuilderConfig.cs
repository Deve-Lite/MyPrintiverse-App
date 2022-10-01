using MyPrintiverse.Core.Services.Link;
using MyPrintiverse.Core.Services.Server;
using MyPrintiverse.FilamentsModule.Filaments;
using MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentCollectionPage;
using MyPrintiverse.FilamentsModule.Filaments.Services;
using MyPrintiverse.FilamentsModule.Spools;
using MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.Services;
using MyPrintiverse.FilamentsModule.Spools.SpoolPage;
using MyPrintiverse.FilamentsModule.Types;
using MyPrintiverse.FilamentsModule.Types.AddFilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.FilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.FilamentTypesPage;
using MyPrintiverse.FilamentsModule.Types.Services;

namespace MyPrintiverse.FilamentsModule;

public static class FilamentBuilderConfig
{

	/// <summary>
	/// Configure filament Services.
	/// </summary>
	/// <param name="builder"></param>
	/// <returns></returns>
	public static MauiAppBuilder ConfigureFilamentServices(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<Core.Services.Device.IDeviceItemService<Filament>, FilamentDeviceService>();
		builder.Services.AddSingleton<IServerItemService<Filament>,FilamentServerService>();
        builder.Services.AddSingleton<ILink<Filament>, FilamentLinks>();
        builder.Services.AddSingleton<IItemService<Filament>, FilamentService>();

        builder.Services.AddSingleton<Core.Services.Device.IDeviceItemKeyService<Spool>, SpoolDeviceService>();
        builder.Services.AddSingleton<Core.Services.Device.IDeviceItemService<Spool>, SpoolDeviceService>();
		builder.Services.AddSingleton<IServerItemService<Spool>, SpoolServerService>();
        builder.Services.AddSingleton<ILink<Spool>, SpoolLinks>();
        builder.Services.AddSingleton<IItemService<Spool>, SpoolService>();
        builder.Services.AddSingleton<IItemKeyService<Spool>, SpoolService>();

        builder.Services.AddSingleton<Core.Services.Device.IDeviceItemService<FilamentType>, FilamentTypeDeviceService>();
		builder.Services.AddSingleton<IServerItemService<FilamentType>, FilamentTypeServerService>();
        builder.Services.AddSingleton<ILink<FilamentType>, FilamentTypeLinks>();
        builder.Services.AddSingleton<IItemService<FilamentType>, FilamentTypeService>();


        /* Mock Services */
        builder.Services.AddSingleton<FilamentMock>();
        builder.Services.AddSingleton<FilamentTypeMock>();
        builder.Services.AddSingleton<SpoolMock>();

        return builder;
	}

	/// <summary>
	/// Configure filaments Views. 
	/// </summary>
	/// <param name="builder"></param>
	/// <returns></returns>
	public static MauiAppBuilder ConfigureFilamentViews(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<FilamentCollectionView>();
		builder.Services.AddSingleton<FilamentView>();
		builder.Services.AddTransient<AddFilamentView>();
		builder.Services.AddTransient<EditFilamentView>();

		builder.Services.AddSingleton<FilamentTypesView>();
		builder.Services.AddSingleton<FilamentTypeView>();
		builder.Services.AddTransient<AddFilamentTypeView>();
		builder.Services.AddTransient<EditFilamentTypeView>();

		builder.Services.AddSingleton<SpoolView>();
		builder.Services.AddTransient<AddSpoolView>();
		builder.Services.AddTransient<EditSpoolView>();


		return builder;
	}

	/// <summary>
	/// Configure filaments ViewModels. 
	/// </summary>
	/// <param name="builder"></param>
	/// <returns></returns>
	public static MauiAppBuilder ConfigureFilamentViewModels(this MauiAppBuilder builder)
	{
		// template
		builder.Services.AddSingleton<FilamentCollectionViewModel>();
		builder.Services.AddSingleton<FilamentViewModel>();
		builder.Services.AddTransient<AddFilamentViewModel>();
		builder.Services.AddTransient<EditFilamentViewModel>();

		builder.Services.AddSingleton<FilamentTypesViewModel>();
		builder.Services.AddSingleton<FilamentTypeViewModel>();
		builder.Services.AddTransient<AddFilamentTypeViewModel>();
		builder.Services.AddTransient<EditFilamentTypeViewModel>();

		builder.Services.AddSingleton<SpoolViewModel>();
		builder.Services.AddTransient<AddSpoolViewModel>();
		builder.Services.AddTransient<EditSpoolViewModel>();


		return builder;
	}
}