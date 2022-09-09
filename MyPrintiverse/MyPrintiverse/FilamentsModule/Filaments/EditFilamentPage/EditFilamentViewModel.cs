using MyPrintiverse.FilamentsModule.Types;

namespace MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;

public class EditFilamentViewModel : BaseEditItemViewModel<Filament>
{
	public EditFilamentViewModel(IMessageService messageService, IItemService<Filament> itemService, IItemService<FilamentType> typeService) : base(messageService, itemService)
	{
	}
}