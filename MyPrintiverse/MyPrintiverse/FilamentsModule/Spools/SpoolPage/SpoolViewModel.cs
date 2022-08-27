using MyPrintiverse.FilamentsModule.Prints;
using MyPrintiverse.FilamentsModule.Prints.AddPrintPage;
using MyPrintiverse.FilamentsModule.Prints.EditPrintPage;
using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;

namespace MyPrintiverse.FilamentsModule.Spools.SpoolPage;

public class SpoolViewModel : BaseKeyCollectionWithitemViewModel<Spool, EditSpoolView, Print, EditPrintView, AddPrintView, AddPrintView>
{
	public SpoolViewModel(MessageService messagingService, SpoolService itemService, PrintService itemsService, PrintService keyItemsService) : base(messagingService, itemService, itemsService, keyItemsService)
	{
	}

    #region Overrides

    protected override async Task OpenItem(Print item)
    {
        throw new Exception("Operation not implemented");
    }

    #endregion
}