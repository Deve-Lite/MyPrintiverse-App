
using MyPrintiverse.Core.Services;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.ViewModels.Collections;

/// <summary>
/// View Model for displaying item and collection of key service.
/// </summary>
/// <typeparam name="TBaseModel"> Model of displayed item </typeparam>
/// <typeparam name="TEditView"> Class (View) displaying collection item.</typeparam>
/// <typeparam name="TCollectionModel"> Model inheriting from BaseModel. Displayed in Collection view </typeparam>
/// <typeparam name="TCollectionAddView"> Class (View) adding item.</typeparam>
/// <typeparam name="TCollectionEditView"> Class (View) editing item.</typeparam>
/// <typeparam name="TCollectionItemView"> Class (View) displaying collection item.</typeparam>
public class BaseKeyCollectionWithitemViewModel<TBaseModel, TEditView, TCollectionModel, TCollectionEditView, TCollectionAddView, TCollectionItemView> :
    BaseKeyCollectionViewModel<TCollectionModel, TCollectionAddView, TCollectionEditView, TCollectionItemView> where TCollectionModel : BaseModel where TBaseModel : BaseModel
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

    public BaseKeyCollectionWithitemViewModel(IMessageService messagingService, IItemService<TBaseModel> itemService, IItemService<TCollectionModel> itemsService, IItemKeyService<TCollectionModel> keyItemsService) : base(messagingService, itemsService, keyItemsService)
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

        await Shell.Current.GoToAsync($"{typeof(TEditView).Name}?Id={Item.Id}", true);
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
            {
                await KeyItemsService.DeleteItemsByKeyAsync(Item.Id);
                await Shell.Current.GoToAsync("..", true);
            }

        IsBusy = false;
    }

    #endregion
}

