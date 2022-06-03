using MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentsPage;
using MyPrintiverse.FilamentsModule.Prints.AddPrintPage;
using MyPrintiverse.FilamentsModule.Prints.EditPrintPage;
using MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.SpoolPage;
using MyPrintiverse.FilamentsModule.Statistics.FilamentStatisticPage;
using MyPrintiverse.FilamentsModule.Types.AddFilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.FilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.FilamentTypesPage;

namespace MyPrintiverse.FilamentsModule
{
    public static class FilamentExtensions
    {
        /// <summary>
        /// Configure filaments Views. 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static MauiAppBuilder ConfigureFilamentViews(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<FilamentsView>();
            builder.Services.AddSingleton<FilamentView>();
            builder.Services.AddSingleton<AddFilamentView>();
            builder.Services.AddSingleton<EditFilamentView>();

            builder.Services.AddSingleton<FilamentTypesView>();
            builder.Services.AddSingleton<FilamentTypeView>();
            builder.Services.AddSingleton<AddFilamentTypeView>();
            builder.Services.AddSingleton<EditFilamentTypeView>();

            builder.Services.AddSingleton<SpoolView>();
            builder.Services.AddSingleton<AddSpoolView>();
            builder.Services.AddSingleton<EditSpoolView>();

            builder.Services.AddSingleton<FilamentStatisticsView>();

            builder.Services.AddSingleton<AddPrintView>();
            builder.Services.AddSingleton<EditPrintView>();


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
            // builder.Services.AddSingleton<...ViewModel>();
            builder.Services.AddSingleton<FilamentsViewModel>();
            builder.Services.AddSingleton<FilamentViewModel>();
            builder.Services.AddSingleton<AddFilamentViewModel>();
            builder.Services.AddSingleton<EditFilamentViewModel>();

            builder.Services.AddSingleton<FilamentTypesViewModel>();
            builder.Services.AddSingleton<FilamentTypeViewModel>();
            builder.Services.AddSingleton<AddFilamentTypeViewModel>();
            builder.Services.AddSingleton<EditFilamentTypeViewModel>();

            builder.Services.AddSingleton<SpoolViewModel>();
            builder.Services.AddSingleton<AddSpoolViewModel>();
            builder.Services.AddSingleton<EditSpoolViewModel>();

            builder.Services.AddSingleton<FilamentStatisticsViewModel>();

            builder.Services.AddSingleton<AddPrintViewModel>();
            builder.Services.AddSingleton<EditPrintViewModel>();

            return builder;
        }


        /// <summary>
        /// Registering Filament routes.
        /// </summary>
        public static void RegisterFilamentRoutes()
        {
            Routing.RegisterRoute(nameof(FilamentsView), typeof(FilamentsView));
            Routing.RegisterRoute(nameof(FilamentView), typeof(FilamentView));
            Routing.RegisterRoute(nameof(AddFilamentView), typeof(AddFilamentView));
            Routing.RegisterRoute(nameof(EditFilamentView), typeof(EditFilamentView));

            Routing.RegisterRoute(nameof(SpoolView), typeof(SpoolView));
            Routing.RegisterRoute(nameof(AddSpoolView), typeof(AddSpoolView));
            Routing.RegisterRoute(nameof(EditSpoolView), typeof(EditSpoolView));

            Routing.RegisterRoute(nameof(FilamentTypesView), typeof(FilamentTypesView));
            Routing.RegisterRoute(nameof(FilamentTypeView), typeof(FilamentTypeView));
            Routing.RegisterRoute(nameof(AddFilamentTypeView), typeof(AddFilamentTypeView));
            Routing.RegisterRoute(nameof(EditFilamentTypeView), typeof(EditFilamentTypeView));

            Routing.RegisterRoute(nameof(AddPrintView), typeof(AddPrintView));
            Routing.RegisterRoute(nameof(EditPrintView), typeof(EditPrintView));

            Routing.RegisterRoute(nameof(FilamentStatisticsView), typeof(FilamentStatisticsView));
        }
    }
}
