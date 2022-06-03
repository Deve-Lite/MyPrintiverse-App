using MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;

namespace MyPrintiverse.FilamentsModule.Types.FilamentTypePage
{
    public class FilamentTypeViewModel : DisplayItemViewModel<FilamentType, EditFilamentTypeView>
    {
        public FilamentTypeViewModel(FilamentTypeService filamentTypeService)
        {
            ItemService = filamentTypeService;
        }
    }
}
