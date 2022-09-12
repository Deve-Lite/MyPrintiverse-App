using MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentPage;
using MyPrintiverse.FilamentsModule.Spools;

namespace MyPrintiverse.FilamentsModule.Filaments.FilamentsPage;

public class FilamentsViewModel : GroupedCollectionViewModel<Filament, AddFilamentView, EditFilamentView, FilamentView>
{
    private readonly IItemKeyService<Spool> _spoolService;
    public FilamentsViewModel(IMessageService messagingService, IItemService<Filament> itemsService, IItemKeyService<Spool> spoolService) : base(messagingService, itemsService)
    {
        _spoolService = spoolService;
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

    protected override void DeleteFromItems(Filament item)
    {
        base.DeleteFromItems(item);
        _spoolService.DeleteItemsByKeyAsync(item.Id);
    }
    #endregion
}
