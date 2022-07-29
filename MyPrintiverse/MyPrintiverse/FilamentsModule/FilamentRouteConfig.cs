using System;
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
	public static class FilamentRouteConfig 
	{
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

