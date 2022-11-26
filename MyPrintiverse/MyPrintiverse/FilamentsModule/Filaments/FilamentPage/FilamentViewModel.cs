using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Spools;
using MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.SpoolPage;

namespace MyPrintiverse.FilamentsModule.Filaments.FilamentPage;

public partial class FilamentViewModel : BaseKeyCollectionWithitemViewModel<Filament, EditFilamentView, Spool, EditSpoolView, AddSpoolView, SpoolView>
{

    [ObservableProperty]
    private bool _isFinishedFilamentsVisible;

    protected override string OpenRoute(Spool item) => $"{nameof(SpoolView)}?Id={item?.Id}&FilamentId={Item.Id}";
    protected override string EditRoute(Spool item) => $"{nameof(EditSpoolView)}?Id={item?.Id}&FilamentId={Item.Id}";
    protected override string AddRoute() => $"{nameof(AddSpoolView)}?FilamentId={Item.Id}";

    public FilamentViewModel(IMessageService messagingService, IItemService<Filament> itemService, IItemService<Spool> itemsService, IItemKeyService<Spool> itemsKeyService) : base(messagingService, itemService, itemsService, itemsKeyService)
    {
    }

    #region Overrides

    public override void OnAppearing()
    {
        base.OnAppearing();
        // TODO Load From Settings
        IsFinishedFilamentsVisible = false;
    }

    protected override async Task Refresh()
    {
        IsRefreshing = true;

        var collection = (List<Spool>) await KeyItemsService.GetItemsByKeyAsync(Id);

        if (!IsFinishedFilamentsVisible)
            collection.RemoveAll(x => x.IsFinished);

        RefreshCollection(SearchedItems, collection, false);

        IsRefreshing = false;
    }

    protected override async Task UpdateCollectionsOnAppearing()
    {
        var collection = (List<Spool>)await KeyItemsService.GetItemsByKeyAsync(Id);

        if (!IsFinishedFilamentsVisible)
            collection.RemoveAll(x => x.IsFinished);

        UpdateCollection(SearchedItems, collection);
    }

    #endregion

    #region Privates

    [RelayCommand]
    private async Task SwitchIsFinishedFilaments()
    {
        IsFinishedFilamentsVisible = !IsFinishedFilamentsVisible;
        await Refresh();
    }

    #endregion

}