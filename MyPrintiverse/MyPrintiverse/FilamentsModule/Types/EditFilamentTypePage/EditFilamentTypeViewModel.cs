

namespace MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;

public class EditFilamentTypeViewModel : BaseEditItemViewModel<FilamentType>
{ 
	public EditFilamentTypeViewModel(MessageService messageService, FilamentTypeService itemService) : base(messageService, itemService)
	{
	}
}