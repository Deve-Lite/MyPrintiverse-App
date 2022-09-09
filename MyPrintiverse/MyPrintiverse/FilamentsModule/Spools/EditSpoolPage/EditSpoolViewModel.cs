
namespace MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;

public class EditSpoolViewModel : BaseEditItemViewModel<Spool>
{
	public EditSpoolViewModel(IMessageService messageService, IItemService<Spool> itemService) : base(messageService, itemService)
	{
	}
}