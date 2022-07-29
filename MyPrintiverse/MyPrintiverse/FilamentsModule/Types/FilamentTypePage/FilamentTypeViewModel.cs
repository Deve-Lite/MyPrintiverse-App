using MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;

namespace MyPrintiverse.FilamentsModule.Types.FilamentTypePage
{
    public class FilamentTypeViewModel : BaseItemViewModel<FilamentType, EditFilamentTypeView>
    {
        public FilamentTypeViewModel(MessageService messageService, FilamentTypeService itemService) : base(messageService,itemService)
        {
            
        }
    }
}
