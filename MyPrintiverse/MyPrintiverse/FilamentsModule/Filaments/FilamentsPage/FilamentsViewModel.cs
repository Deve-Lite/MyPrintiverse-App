using MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentPage;


namespace MyPrintiverse.FilamentsModule.Filaments.FilamentsPage;

public class FilamentsViewModel : GroupedCollectionViewModel<Filament, AddFilamentView, EditFilamentView, FilamentView>
{ 
    public FilamentsViewModel(IMessageService messagingService, IItemService<Filament> itemsService) : base(messagingService, itemsService)
    {
    }

    #region Overrides

    protected override string GetNewGroupName(Filament item) => item.Brand.Trim();

    protected override int GetIndex(Filament item)
    {
        var foundItem = Items.FirstOrDefault(x => x.Name == item.Brand);

        if (foundItem == null)
                return -1;

        return Items.IndexOf(foundItem);
    }

    #endregion
}
