

namespace MyPrintiverse.FilamentsModule.Prints.AddPrintPage;

public class AddPrintViewModel : BaseAddItemViewModel<Print>
{
	public AddPrintViewModel(IMessageService messageService, IItemService<Print> itemService) : base(messageService ,itemService)
	{
	}
}