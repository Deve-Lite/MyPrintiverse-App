

namespace MyPrintiverse.FilamentsModule.Prints.AddPrintPage
{
    public class AddPrintViewModel : BaseAddItemViewModel<Spool>
    {
        public AddPrintViewModel(MessageService messageService, PrintService itemService) : base(messageService ,itemService)
        {
        }
    }
}
