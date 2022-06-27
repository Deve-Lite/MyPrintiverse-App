

namespace MyPrintiverse.BaseViewModels.Collection;

/// <summary>
/// Default view model for displaying item and connected to item collection.
/// </summary>
/// <typeparam name="TBaseModel"> Displayed item</typeparam>
/// <typeparam name="TEdit"> Edit Item view.</typeparam>
/// <typeparam name="TBaseCollectionModel"> Base model for item in collection </typeparam>
/// <typeparam name="TCollectionAdd"> Add new collection item</typeparam>
/// <typeparam name="TCollectionEdit">Edit new collection item</typeparam>
/// <typeparam name="TCollectionDispaly"> Display item from collection </typeparam>
public abstract class BaseCollectionWithItemViewModel<TBaseModel, TEdit, TBaseCollectionModel, TCollectionAdd, TCollectionEdit, TCollectionDispaly> : BaseCollectionViewModel<TBaseCollectionModel, TCollectionAdd, TCollectionEdit, TCollectionDispaly> where TBaseModel : BaseModel where TBaseCollectionModel : BaseModel
{
    private TBaseModel item;
    public TBaseModel Item { get => item; set => SetProperty(ref item, value); }

    public AsyncCommand EditDisplayItemCommand { get; set; }
    public AsyncCommand DeleteDisplayItemCommand { get; set; }

    IItemAsyncService<TBaseModel> ItemService;

    public BaseCollectionWithItemViewModel(IMessageService messagingService, IItemAsyncService<TBaseModel> itemService, IItemAsyncService<TBaseCollectionModel> itemsService) : base(messagingService, itemsService)
{
        var itemServiceExceptionMessage = GetExceptionMessage<BaseCollectionWithItemViewModel<TBaseModel, TEdit, TBaseCollectionModel, TCollectionAdd, TCollectionEdit, TCollectionDispaly>>(nameof(itemsService));
        ItemService = itemService ?? throw new ArgumentNullException(itemServiceExceptionMessage);
    }

    protected internal override void OnAppearing()
    {
        EditDisplayItemCommand = new AsyncCommand(EditDisplayItem, CanExecute);
        DeleteDisplayItemCommand = new AsyncCommand(DeleteDisplayItem, CanExecute);
        base.OnAppearing();
    }

    protected virtual async Task EditDisplayItem() => await Shell.Current.GoToAsync($"{typeof(TEdit).Name}", true);

    /// <summary>
    /// By default deletes only Item.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task DeleteDisplayItem()
    {
        if(await ItemService.DeleteItemAsync(Item.Id))
            await Shell.Current.GoToAsync("..", true);
        
        IsBusy = false;
    }

    protected override Task UpdateItemsOnAppearing()
    {
        return base.UpdateItemsOnAppearing();
    }

    protected override Task RefreshItems()
    {
        return base.RefreshItems();
    }
}
