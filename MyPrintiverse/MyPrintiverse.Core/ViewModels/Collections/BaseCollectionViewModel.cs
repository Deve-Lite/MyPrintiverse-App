using MyPrintiverse.Core.Services;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.ViewModels.Collections;

/// <summary>
/// View model for displaying single Collection with base commands.
/// </summary>
/// <typeparam name="TBaseModel"> Model </typeparam>
/// <typeparam name="TAddView"> Class (View) adding model.</typeparam>
/// <typeparam name="TEditView"> Class (View) editing model.</typeparam>
/// <typeparam name="TItemView"> Class (View) displaying model.</typeparam>
public abstract class BaseCollectionViewModel<TBaseModel, TAddView, TEditView, TItemView> : BaseViewModel where TBaseModel : BaseModel
{
    #region List
    /// <summary>
    /// Base collection of TBaseModel.
    /// </summary>
    public ObservableCollection<TBaseModel> Items { get; set; }

    #endregion

    #region Commands

    /// <summary>
    /// Command for refreshing collection.
    /// </summary>
    public AsyncCommand RefreshItemsCommand { get; set; }
    /// <summary>
    /// Command for adding new item to collection.
    /// </summary>
    public AsyncCommand AddItemCommand { get; set; }
    /// <summary>
    /// Command for displaying multiple manage options for collection item. 
    /// </summary>
    public AsyncCommand<TBaseModel> ItemOptionsCommand { get; set; }
    /// <summary>
    /// Command for displaying single item from collection.
    /// </summary>
    public AsyncCommand<TBaseModel> OpenItemCommand { get; set; }
    /// <summary>
    /// Command for deleting one item from collection.
    /// </summary>
    public AsyncCommand<TBaseModel> DeleteItemCommand { get; set; }
    /// <summary>
    /// Command for editing one item from collection.
    /// </summary>
    public AsyncCommand<TBaseModel> EditItemCommand { get; set; }

    #endregion

    #region Services

    /// <summary>
    /// Collection service.
    /// </summary>
    protected IItemService<TBaseModel> ItemsService;
    /// <summary>
    /// Message service.
    /// </summary>
    protected IMessageService MessageService;
    #endregion

    public BaseCollectionViewModel(IMessageService messageService, IItemService<TBaseModel> itemsService)
    {
        var messageServiceExceptionMessage = GetExceptionMessage<BaseCollectionViewModel<TBaseModel, TAddView, TEditView, TItemView>>(nameof(messageService));
        MessageService = messageService ?? throw new ArgumentNullException(messageServiceExceptionMessage);

        var itemsServiceExceptionMessage = GetExceptionMessage<BaseCollectionViewModel<TBaseModel, TAddView, TEditView, TItemView>>(nameof(itemsService));
        ItemsService = itemsService ?? throw new ArgumentNullException(itemsServiceExceptionMessage);

        Items = new ObservableCollection<TBaseModel>();

        RefreshItemsCommand = new AsyncCommand(RefreshItems, CanExecute, shellExecute: ExecuteBlockade);
        AddItemCommand = new AsyncCommand(AddItem, CanExecute, shellExecute: ExecuteBlockade);
        EditItemCommand = new AsyncCommand<TBaseModel>(EditItem, CanExecute, shellExecute: ExecuteBlockade);
        OpenItemCommand = new AsyncCommand<TBaseModel>(OpenItem, CanExecute, shellExecute: ExecuteBlockade);
        DeleteItemCommand = new AsyncCommand<TBaseModel>(DeleteItem, CanExecute, shellExecute: ExecuteBlockade);
        ItemOptionsCommand = new AsyncCommand<TBaseModel>(ItemOptions, CanExecute, shellExecute: ExecuteBlockade);
    }

    #region OnAppearing

    public override async void OnAppearing()
    {
        base.OnAppearing();

        await UpdateItemsOnAppearing();
    }

    /// <summary>
    /// Task to perfrom when page is loading, designed for refresh collection with new data.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task UpdateItemsOnAppearing()
    { 

        var data = (List<TBaseModel>)await ItemsService.GetItemsAsync();

        int i = 0;
        foreach (var item in new List<TBaseModel>(Items))
        {
            var newItem = data.First(x => x.Id == item.Id);

            if (newItem == null)
            {
                Items.Remove(item);
            }
            else if (item.EditedAt != newItem.EditedAt)
            {
                Items[Items.IndexOf(item)] = newItem;
                data.Remove(item);
            }
            else if (newItem.EditedAt == item.EditedAt)
                data.Remove(newItem);
        }

        foreach (TBaseModel item in data)
            Items.Add(item);
    }

    #endregion

    #region CollectionRefresh

    /// <summary>
    /// Task to perform when RefreshItemsCommand occurs.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task RefreshItems()
    {

        IsRefreshing = true;

        Items.Clear();

        foreach (var item in await ItemsService.GetItemsAsync())
            AddToItems(item);

        SortItems();

        IsRefreshing = false;
    }

    /// <summary>
    /// Method adds item to collection as new group or to existing group. Method used in DeleteItem.
    /// </summary>
    /// <param name="item"> Model. </param>
    protected virtual void AddToItems(TBaseModel item) => Items.Add(item);

    /// <summary>
    /// After updating or refreshing, list of Items is sorted by this function.
    /// </summary>
    protected virtual void SortItems() { }

    #endregion

    #region ItemManage

    /// <summary>
    /// Task to perform when ItemOptionCommand occurs.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected virtual async Task ItemOptions(TBaseModel item)
    {
        var action = await MessageService.ShowActionSheetAsync<BaseItemActions>("Actions:");

        if (action == BaseItemActions.Open)
            await OpenItem(item);
        else if (action == BaseItemActions.Delete)
            await DeleteItem(item);
        else if (action == BaseItemActions.Edit)
            await EditItem(item);

    }


    /// <summary>
    /// Task to perform when AddItemCommand occurs.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task AddItem() => await Shell.Current.GoToAsync($"{typeof(TAddView).Name}");

    /// <summary>
    /// Task to perform when EditItemCommand occurs.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected virtual async Task EditItem(TBaseModel item) => await Shell.Current.GoToAsync($"{typeof(TEditView).Name}?Id={item.Id}");

    /// <summary>
    /// Task to perform when DeleteItemCommand occurs.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected virtual async Task DeleteItem(TBaseModel item)
    {
        if (!(await MessageService.ShowSelectAlertAsync("Item Delete", "Do you really want to delete this item?", "Delete")))
            return;

        if (await ItemsService.DeleteItemAsync(item.Id))
            DeleteFromItems(item);
    }

    /// <summary>
    /// Method deletes item from collection. Method used in DeleteItem.
    /// </summary>
    /// <param name="item"> Model. </param>
    protected virtual void DeleteFromItems(TBaseModel item)
    {
        Items.Remove(item);
    }

    /// <summary>
    /// Task to perform when OpenItemCommand occurs.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected virtual async Task OpenItem(TBaseModel item) => await Shell.Current.GoToAsync($"{typeof(TItemView).Name}?Id={item.Id}");

    #endregion
}

