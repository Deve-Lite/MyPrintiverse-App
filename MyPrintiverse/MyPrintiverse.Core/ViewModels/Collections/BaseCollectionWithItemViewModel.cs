﻿

using MyPrintiverse.Core.Services;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.ViewModels.Collections;

/// <summary>
/// Default view model for displaying item and connected collection.
/// </summary>
/// <typeparam name="TBaseModel"> Displayed item</typeparam>
/// <typeparam name="TEditView"> Edit Item view.</typeparam>
/// <typeparam name="TCollectionModel"> Base model for item in collection </typeparam>
/// <typeparam name="TCollectionAddView"> Add new collection item</typeparam>
/// <typeparam name="TCollectionEditView">Edit new collection item</typeparam>
/// <typeparam name="TCollectionItemView"> Display item from collection </typeparam>
[QueryProperty(nameof(Id), nameof(Id))]
public abstract class BaseCollectionWithItemViewModel<TBaseModel, TEditView, TCollectionModel, TCollectionAddView, TCollectionEditView, TCollectionItemView> : BaseCollectionViewModel<TCollectionModel, TCollectionAddView, TCollectionEditView, TCollectionItemView> where TBaseModel : BaseModel where TCollectionModel : BaseModel
{

    #region Fields

    /// <summary>
    /// item backing storage.
    /// </summary>
    private TBaseModel item;
    /// <summary>
    /// Item for displaying 
    /// </summary>
    public TBaseModel Item { get => item; set => SetProperty(ref item, value); }

    /// <summary>
    /// Item id from querry.
    /// </summary>
    public string Id { get; set; }

    #endregion

    #region Commands

    /// <summary>
    /// Command for view, designed to open page with item edition.
    /// </summary>
    public AsyncRelayCommand EditDisplayItemCommand { get; set; }
    /// <summary>
    /// Command for view, designed to delete item.
    /// </summary>
    public AsyncRelayCommand DeleteDisplayItemCommand { get; set; }

    #endregion

    #region Services

    /// <summary>
    /// Service of diplayed Item.
    /// </summary>
    IItemService<TBaseModel> ItemService;

    #endregion

    public BaseCollectionWithItemViewModel(IMessageService messagingService, IItemService<TBaseModel> itemService, IItemService<TCollectionModel> itemsService) : base(messagingService, itemsService)
{
        ItemService = itemService;

        EditDisplayItemCommand = new AsyncRelayCommand(EditDisplayItem, CanExecute);
        DeleteDisplayItemCommand = new AsyncRelayCommand(DeleteDisplayItem, CanExecute);
    }

    #region Overrides
    public override async void OnAppearing()
    {
        base.OnAppearing();
        Item = await ItemService.GetItemAsync(Id);
    }

    #endregion

    #region Virtual Methods

    /// <summary>
    /// Task connected to EditDisplayItemCommand.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task EditDisplayItem()
    {
        if (AnyActionStartedCommand())
            return;

        await Shell.Current.GoToAsync($"{typeof(TEditView).Name}", true);
    }

    /// <summary>
    /// Task connected to DeleteDisplayedItemCommand. By default deletes only Item.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task DeleteDisplayItem()
    {
        if (AnyActionStartedCommand())
            return;

        if (await MessageService.ShowSelectAlertAsync("Item Delete", "Do you really want to delete this item?", "Delete"))
            if (await ItemService.DeleteItemAsync(Item.Id))
                await Shell.Current.GoToAsync("..", true);

        IsBusy = false;
    }

    #endregion
}
