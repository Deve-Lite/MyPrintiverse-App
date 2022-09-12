using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;

namespace MyPrintiverse.FilamentsModule.Spools.SpoolPage;

public class SpoolViewModel : BaseItemViewModel<Spool, EditSpoolView> //BaseKeyCollectionWithitemViewModel<Spool, EditSpoolView, Print, EditPrintView, AddPrintView, AddPrintView>
{
	public SpoolViewModel(IMessageService messagingService, IItemService<Spool> itemService) : base(messagingService, itemService)
	{
	}
}