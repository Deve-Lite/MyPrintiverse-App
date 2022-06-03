

namespace MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage
{
    public class EditFilamentTypeViewModel : EditItemViewModel<FilamentType>
    {
        public EditFilamentTypeViewModel(FilamentTypeService filamentTypeService)
        {
            ItemService = filamentTypeService;
        }
    }
}
