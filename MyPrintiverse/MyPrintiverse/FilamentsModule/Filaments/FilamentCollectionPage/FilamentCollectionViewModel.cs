﻿using MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentPage;
using MyPrintiverse.FilamentsModule.Spools;

namespace MyPrintiverse.FilamentsModule.Filaments.FilamentCollectionPage;

public class FilamentCollectionViewModel : GroupedCollectionViewModel<Filament, AddFilamentView, EditFilamentView, FilamentView>
{
    private readonly IItemKeyService<Spool> _spoolService;
    public FilamentCollectionViewModel(IMessageService messagingService, IItemService<Filament> itemsService, IItemKeyService<Spool> spoolService) : base(messagingService, itemsService)
    {
        _spoolService = spoolService;
    }

    #region Overrides

    protected override string GetNewGroupName(Filament item) => item.Brand.Trim();

    protected override int GetIndex(Filament item)
    {
        var foundItem = SearchedItems.FirstOrDefault(x => x.Name == item.Brand);

        if (foundItem == null)
                return -1;

        return SearchedItems.IndexOf(foundItem);
    }

    protected override void DeleteFromSearchedItems(Filament item)
    {
        base.DeleteFromSearchedItems(item);
        _spoolService.DeleteItemsByKeyAsync(item.Id);
    }

    protected override bool MatchQuery(Filament item, string query)
    {
        return item.Brand.Contains(query, StringComparison.CurrentCultureIgnoreCase) || item.Tag.Contains(query, StringComparison.CurrentCultureIgnoreCase);
    }

    #endregion
}
