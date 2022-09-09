

namespace MyPrintiverse.FilamentsModule.Prints.EditPrintPage;

public class EditPrintViewModel : BaseEditItemViewModel<Print>
{
	public EditPrintViewModel(IMessageService messageService, IItemService<Print> itemService) : base(messageService, itemService)
	{
	}
}