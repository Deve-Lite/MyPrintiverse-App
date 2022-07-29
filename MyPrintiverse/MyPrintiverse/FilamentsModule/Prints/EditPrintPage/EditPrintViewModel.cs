

namespace MyPrintiverse.FilamentsModule.Prints.EditPrintPage
{
    public class EditPrintViewModel : BaseEditItemViewModel<Spool>
    {
        public EditPrintViewModel(MessageService messageService, PrintService itemService) : base(messageService, itemService)
        {
        }
    }
}
