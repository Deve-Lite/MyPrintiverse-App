﻿using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Spools;
using MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.SpoolPage;
using System.Collections.ObjectModel;

namespace MyPrintiverse.FilamentsModule.Filaments.FilamentPage;

public class FilamentViewModel : BaseKeyCollectionWithitemViewModel<Filament, EditFilamentView, Spool, AddSpoolView, EditSpoolView, SpoolView>
{
    public ObservableCollection<Spool> FinishedFilaments { get; set; } 

    public FilamentViewModel(MessageService messagingService, FilamentService itemService, SpoolService itemsService) : base(messagingService, itemService, itemsService, itemsService)
    {
        FinishedFilaments = new ObservableCollection<Spool>();
    }

    #region Overrides

    protected override async Task Refresh()
    {
        var normalCollection = new List<Spool>();
        var finishedCollection = new List<Spool>();

        SplitItems(normalCollection, finishedCollection, await KeyItemsService.GetItemsByKeyAsync(Id));

        IsRefreshing = true;
        await RefreshCollection(Items, normalCollection, false);
        await RefreshCollection(FinishedFilaments, finishedCollection, false);
        IsRefreshing = false;
    }

    protected override async Task UpdateCollectionsOnAppearing()
    {
        var normalCollection = new List<Spool>();
        var finishedCollection = new List<Spool>();

        SplitItems(normalCollection, finishedCollection, await KeyItemsService.GetItemsByKeyAsync(Id));

        await UpdateCollection(Items, normalCollection);
        await UpdateCollection(FinishedFilaments, finishedCollection);
    }

    protected override async Task AddItem() => await Shell.Current.GoToAsync($"{nameof(AddSpoolView)}?Id={Item.Id}");

    #endregion

    #region Privates

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