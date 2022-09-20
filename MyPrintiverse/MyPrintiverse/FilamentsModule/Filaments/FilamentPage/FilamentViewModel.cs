using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.IdentityModel.Tokens;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Spools;
using MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.SpoolPage;
using System.Collections.ObjectModel;

namespace MyPrintiverse.FilamentsModule.Filaments.FilamentPage;

public partial class FilamentViewModel : BaseKeyCollectionWithitemViewModel<Filament, EditFilamentView, Spool, AddSpoolView, EditSpoolView, SpoolView>
{

    [ObservableProperty]
    private bool _isFinishedFilamentsVisible;

    public ObservableCollection<Spool> FinishedFilaments { get; set; } 

    public FilamentViewModel(IMessageService messagingService, IItemService<Filament> itemService, IItemService<Spool> itemsService, IItemKeyService<Spool> itemsKeyService) : base(messagingService, itemService, itemsService, itemsKeyService)
    {
        FinishedFilaments = new ObservableCollection<Spool>();
    }

    #region Overrides

    public override void OnAppearing()
    {
        base.OnAppearing();
        // TODO Load From Settings
        IsFinishedFilamentsVisible = false && FinishedFilaments.Count != 0;
    }

    protected override async Task Refresh()
    {
        var normalCollection = new List<Spool>();
        var finishedCollection = new List<Spool>();

        SplitItems(normalCollection, finishedCollection, await KeyItemsService.GetItemsByKeyAsync(Id));

        IsRefreshing = true;
        RefreshCollection(Items, normalCollection, false);
        if (IsFinishedFilamentsVisible)
            RefreshCollection(FinishedFilaments, finishedCollection, false);
        IsRefreshing = false;
    }

    protected override async Task UpdateCollectionsOnAppearing()
    {
        var normalCollection = new List<Spool>();
        var finishedCollection = new List<Spool>();

        SplitItems(normalCollection, finishedCollection, await KeyItemsService.GetItemsByKeyAsync(Id));

        UpdateCollection(Items, normalCollection);

        if (IsFinishedFilamentsVisible)
            UpdateCollection(FinishedFilaments, finishedCollection);
        
    }

    protected override async Task AddItem() => await Shell.Current.GoToAsync($"{nameof(AddSpoolView)}?Id={Item.Id}");

    protected override void DeleteFromItems(Spool item)
    {
        if (Items.Any(x => x.Id==item.Id))
            RemoveFromCollection(Items, item);
        else
            RemoveFromCollection(FinishedFilaments, item);
    }

    protected override async Task OpenItem(Spool item)
    {
        if (AnyActionStartedCommand())
            return;

         await OpenPage($"{nameof(SpoolView)}?Id={item?.Id}&FilamentId={Item.Id}");
    }

    #endregion

    #region Privates

    [RelayCommand]
    private async Task SwitchIsFinishedFilaments()
    {
        IsFinishedFilamentsVisible = !IsFinishedFilamentsVisible;
        await Refresh();
    }

    private void SplitItems(List<Spool> normalCollection, List<Spool> finishedCollection, IEnumerable<Spool> items)
    {
        foreach (var item in items)
        {
            if (item.IsFinished)
                finishedCollection.Add(item);
            else
                normalCollection.Add(item);
        }
    }

    #endregion

}