

namespace MyPrintiverse.BaseViewModels.Collection;

/// <summary>
/// Default view model for displaying item and connected collection.
/// </summary>
/// <typeparam name="TBaseModel"> Displayed item</typeparam>
/// <typeparam name="TEdit"> Edit Item view.</typeparam>
/// <typeparam name="TCollectionModel"> Base model for item in collection </typeparam>
/// <typeparam name="TCollectionAdd"> Add new collection item</typeparam>
/// <typeparam name="TCollectionEdit">Edit new collection item</typeparam>
/// <typeparam name="TCollectionDispaly"> Display item from collection </typeparam>
[QueryProperty(nameof(Id), nameof(Id))]
public abstract class BaseCollectionWithItemViewModel<TBaseModel, TEdit, TCollectionModel, TCollectionAdd, TCollectionEdit, TCollectionDispaly> : BaseCollectionViewModel<TCollectionModel, TCollectionAdd, TCollectionEdit, TCollectionDispaly> where TBaseModel : BaseModel where TCollectionModel : BaseModel
{
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

    /// <summary>
    /// Command for view, designed to open page with item edition.
    /// </summary>
    public AsyncCommand EditDisplayItemCommand { get; set; }
    /// <summary>
    /// Command for view, designed to delete item.
    /// </summary>
    public AsyncCommand DeleteDisplayItemCommand { get; set; }

    /// <summary>
    /// Service of diplayed Item.
    /// </summary>
    IItemAsyncService<TBaseModel> ItemService;

    public BaseCollectionWithItemViewModel(IMessageService messagingService, IItemAsyncService<TBaseModel> itemService, IItemAsyncService<TCollectionModel> itemsService) : base(messagingService, itemsService)
{
        var itemServiceExceptionMessage = GetExceptionMessage<BaseCollectionWithItemViewModel<TBaseModel, TEdit, TCollectionModel, TCollectionAdd, TCollectionEdit, TCollectionDispaly>>(nameof(itemsService));
        ItemService = itemService ?? throw new ArgumentNullException(itemServiceExceptionMessage);
    }

    protected internal override async void OnAppearing()
    {
        EditDisplayItemCommand = new AsyncCommand(EditDisplayItem, CanExecute);
        DeleteDisplayItemCommand = new AsyncCommand(DeleteDisplayItem, CanExecute);

        Item = await ItemService.GetItemAsync(Id);

        base.OnAppearing();
    }

    /// <summary>
    /// Task connected to EditDisplayItemCommand.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task EditDisplayItem() => await Shell.Current.GoToAsync($"{typeof(TEdit).Name}", true);

    /// <summary>
    /// Task connected to DeleteDisplayedItemCommand. By default deletes only Item.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task DeleteDisplayItem()
    {
        // make sure to delete
        if(await ItemService.DeleteItemAsync(Item.Id))
            await Shell.Current.GoToAsync("..", true);
        
        IsBusy = false;
    }
}
