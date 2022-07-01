
namespace MyPrintiverse.FilamentsModule.Spools.EditSpoolPage
{
    public class EditSpoolViewModel : BaseEditItemViewModel<Spool>
    {
        public EditSpoolViewModel(MessageService messageService, SpoolService itemService) : base(messageService, itemService)
        {
        }
    }
}
