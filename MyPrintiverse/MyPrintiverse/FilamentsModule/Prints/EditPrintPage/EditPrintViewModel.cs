

namespace MyPrintiverse.FilamentsModule.Prints.EditPrintPage;

public class EditPrintViewModel : BaseEditItemViewModel<Print>
{
	public EditPrintViewModel(MessageService messageService, PrintService itemService) : base(messageService, itemService)
	{
	}
}
