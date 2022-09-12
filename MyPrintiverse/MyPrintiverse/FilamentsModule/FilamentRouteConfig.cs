using MyPrintiverse.Admin.Tests;
using MyPrintiverse.Admin;
using MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentsPage;
using MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.SpoolPage;
using MyPrintiverse.FilamentsModule.Statistics.FilamentStatisticPage;
using MyPrintiverse.FilamentsModule.Types.AddFilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.FilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.FilamentTypesPage;

namespace MyPrintiverse.FilamentsModule;

public class FilamentRouteConfig : RouteRegister
{
    public override void RegisterRoutes()
    {
        var routes = new List<Type>()
        {
            typeof(FilamentCollectionView),
            typeof(FilamentView),
            typeof(AddFilamentView),
            typeof(EditFilamentView),

            typeof(SpoolView),
            typeof(AddSpoolView),
            typeof(EditSpoolView),

            typeof(FilamentTypesView),
            typeof(FilamentTypeView),
            typeof(AddFilamentTypeView),
            typeof(EditFilamentTypeView),

            typeof(FilamentStatisticsView)
        };

        Register(routes);
    }
}