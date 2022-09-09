

namespace MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;

public class EditFilamentTypeViewModel : BaseEditItemViewModel<FilamentType>
{ 
	public EditFilamentTypeViewModel(IMessageService messageService, IItemService<FilamentType> itemService) : base(messageService, itemService)
	{
	}
}