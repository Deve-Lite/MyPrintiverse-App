using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.IdentityModel.Tokens;
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

    [ObservableProperty]
    public bool _searchBarIsVisible;

    protected override string OpenRoute(Spool item) => $"{nameof(SpoolView)}?Id={item?.Id}&FilamentId={Item.Id}";
    protected override string EditRoute(Spool item) => $"{nameof(EditSpoolView)}?Id={item?.Id}&FilamentId={Item.Id}";
    protected override string AddRoute() => $"{nameof(AddSpoolView)}?FilamentId={Item.Id}";

    public FilamentViewModel(IMessageService messagingService, IItemService<Filament> itemService, IItemService<Spool> itemsService, IItemKeyService<Spool> itemsKeyService) : base(messagingService, itemService, itemsService, itemsKeyService)
    {
    }

    [RelayCommand]
    public void SearchBarEnable() 
    {
        if (SearchBarIsVisible)
        {
            SearchBarIsVisible = false;
            SearchItems("");
        }
        else
        {
            SearchBarIsVisible = true;
        }
    }

    #region Overrides

    public override void OnAppearing()
    {
        base.OnAppearing();
        // TODO Load From Settings
        IsFinishedFilamentsVisible = false;
    }

    public override void SearchItems(string query)
    {
        if (query.IsNullOrEmpty())
        {

            var collection = new List<Spool>(Items);

            if (!IsFinishedFilamentsVisible)
                collection.RemoveAll(x => x.IsFinished);

            UpdateCollection(SearchedItems, collection);
            return;
        }

        var filteredItems = Items.Where(item => MatchQuery(item, query)).ToList();

        if (!IsFinishedFilamentsVisible)
            filteredItems.RemoveAll(x => x.IsFinished);

        foreach (Spool item in Items)
        {
            if (!filteredItems.Contains(item))
                SearchedItems.Remove(item);
            else if (!SearchedItems.Contains(item))
                SearchedItems.Add(item);
        }
    }

    protected override async Task Refresh()
    {
        IsRefreshing = true;

        Items = (List<Spool>) await KeyItemsService.GetItemsByKeyAsync(Id);

        var collection = new List<Spool>(Items);

        if (!IsFinishedFilamentsVisible)
            collection.RemoveAll(x => x.IsFinished);

        RefreshCollection(SearchedItems, collection, false);

        IsRefreshing = false;
    }

    protected override async Task UpdateCollectionsOnAppearing()
    {
        Items = (List<Spool>)await KeyItemsService.GetItemsByKeyAsync(Id);

        var collection = new List<Spool>(Items);

        if (!IsFinishedFilamentsVisible)
            collection.RemoveAll(x => x.IsFinished);

        UpdateCollection(SearchedItems, collection);
    }

    protected override bool MatchQuery(Spool item, string query)
    {
        return item.Tag.Contains(query, StringComparison.CurrentCultureIgnoreCase);
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