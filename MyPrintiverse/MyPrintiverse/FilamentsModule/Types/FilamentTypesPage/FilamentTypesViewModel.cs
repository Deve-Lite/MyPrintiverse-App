using MyPrintiverse.FilamentsModule.Types.AddFilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.FilamentTypePage;

namespace MyPrintiverse.FilamentsModule.Types.FilamentTypesPage
{
    public class FilamentTypesViewModel : BaseCollectionViewModel<FilamentType, AddFilamentTypeView,EditFilamentTypeView, FilamentTypeView>
    {
        public FilamentTypesViewModel(IMessageService messageService, FilamentTypeService itemsService) : base(messageService, itemsService)
        {
        }
    }
}
