

namespace MyPrintiverse.FilamentsModule.Prints.AddPrintPage;

public class AddPrintViewModel : BaseAddItemViewModel<Print>
{
	public AddPrintViewModel(MessageService messageService, PrintService itemService) : base(messageService ,itemService)
	{
	}
}
