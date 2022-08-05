using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Spools;
using MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.SpoolPage;

namespace MyPrintiverse.FilamentsModule.Filaments.FilamentPage;

public class FilamentViewModel : BaseKeyCollectionWithitemViewModel<Filament, EditFilamentView, Spool, AddSpoolView, EditSpoolView, SpoolView>
{
    public FilamentViewModel(MessageService messagingService, FilamentService itemService, SpoolService itemsService) : base(messagingService, itemService, itemsService, itemsService  )
    {
    }

    #region Overrides

    

    #endregion
}