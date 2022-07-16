

using MyPrintiverse.Core.Items;
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

    /// <summary>
    /// item backing storage.
    /// </summary>
    private TBaseModel item;
    /// <summary>
    /// Item for displaying 
    /// </summary>
    public TBaseModel Item { get => item; set => SetProperty(ref item, value); }

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

    public BaseKeyCollectionWithitemViewModel(IMessageService messagingService, IItemService<TBaseModel> itemService, IItemService<TCollectionModel> itemsService, IItemKeyService<TCollectionModel> keyItemsService) : base(messagingService, itemsService, keyItemsService)
    {
        var keyItemServiceExceptionMessage = GetExceptionMessage<BaseKeyCollectionWithitemViewModel<TBaseModel, TEditView, TCollectionModel, TCollectionEditView, TCollectionAddView, TCollectionItemView>>(nameof(itemsService));
        ItemService = itemService ?? throw new ArgumentNullException(keyItemServiceExceptionMessage);
    }

    public override async void OnAppearing()
    {
        EditDisplayItemCommand = new AsyncCommand(EditDisplayItem, CanExecute, shellExecute: ExecuteBlockade);
        DeleteDisplayItemCommand = new AsyncCommand(DeleteDisplayItem, CanExecute, shellExecute: ExecuteBlockade);

        Item = await ItemService.GetItemAsync(Id);

        base.OnAppearing();
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
        // make sure to delete
        if (await ItemService.DeleteItemAsync(Item.Id))
            await Shell.Current.GoToAsync("..", true);

    }
}

