using MyPrintiverse.FilamentsModule.Types.AddFilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.FilamentTypePage;

namespace MyPrintiverse.FilamentsModule.Types.FilamentTypesPage
{
    public class FilamentTypesViewModel : CollectionViewModel<FilamentType, AddFilamentTypeView,EditFilamentTypeView, FilamentTypeView>
    {
        public FilamentTypesViewModel(FilamentTypeService filamentTypeService)
        {
            ItemsService = filamentTypeService;
        }
    }
}
