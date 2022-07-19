

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
    IItemService<TBaseModel> ItemService;

    public BaseCollectionWithItemViewModel(IMessageService messagingService, IItemService<TBaseModel> itemService, IItemService<TCollectionModel> itemsService) : base(messagingService, itemsService)
{
        var itemServiceExceptionMessage = GetExceptionMessage<BaseCollectionWithItemViewModel<TBaseModel, TEditView, TCollectionModel, TCollectionAddView, TCollectionEditView, TCollectionItemView>>(nameof(itemsService));
        ItemService = itemService ?? throw new ArgumentNullException(itemServiceExceptionMessage);
    }

    public override async void OnAppearing()
    {
        base.OnAppearing();

        EditDisplayItemCommand = new AsyncCommand(EditDisplayItem, CanExecute, shellExecute: ExecuteBlockade);
        DeleteDisplayItemCommand = new AsyncCommand(DeleteDisplayItem, CanExecute, shellExecute: ExecuteBlockade);

        Item = await ItemService.GetItemAsync(Id);
    }

    /// <summary>
    /// Task connected to EditDisplayItemCommand.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task EditDisplayItem() => await Shell.Current.GoToAsync($"{typeof(TEditView).Name}", true);

    /// <summary>
    /// Task connected to DeleteDisplayedItemCommand. By default deletes only Item.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task DeleteDisplayItem()
    {
        if (!(await MessageService.ShowSelectAlertAsync("Item Delete", "Do you really want to delete this item?", "Delete")))
            return;

        if (await ItemService.DeleteItemAsync(Item.Id))
            await Shell.Current.GoToAsync("..", true);
        
    }
}
