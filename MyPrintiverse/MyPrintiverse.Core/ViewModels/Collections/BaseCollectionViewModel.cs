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
    public AsyncCommand RefreshCommand { get; set; }
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

        RefreshCommand = new AsyncCommand(Refresh, CanExecute, shellExecute: ExecuteBlockade);
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

        await UpdateCollectionsOnAppearing();
    }

    /// <summary>
    /// Task to perfrom when page is loading, designed for refresh collection with new data.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task UpdateCollectionsOnAppearing()
    { 
        await UpdateCollection((List<TBaseModel>)await ItemsService.GetItemsAsync(), Items);
    }

    /// <summary>
    /// Task to perform when RefreshCommand occurs.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task Refresh()
    {
        await RefreshCollection(Items, await ItemsService.GetItemsAsync());
    }

    #endregion

    #region Collection

    /// <summary>
    /// Updates colection with new items.
    /// </summary>
    /// <param name="newItems"> Items for update. </param>
    /// <param name="Collection"> Collection with items to update. </param>
    /// <returns></returns>
    protected virtual async Task UpdateCollection(List<TBaseModel> newItems, ObservableCollection<TBaseModel> Collection, bool addRemaingItems = true)
    {
        foreach (var oldItem in new List<TBaseModel>(Collection))
        {
            var newItem = newItems.First(x => x.Id == oldItem.Id);

            if (newItem == null)
            {
                RemoveFromCollection(Collection, oldItem);
            }
            else if (oldItem.EditedAt != newItem.EditedAt)
            {
                EditInCollection(Collection, newItem, oldItem);
                newItems.Remove(newItem);
            }
            else if (newItem.EditedAt == oldItem.EditedAt)
                newItems.Remove(newItem);
        }

        if (addRemaingItems)
        {
            foreach (TBaseModel item in newItems)
                AddToCollection(Collection, item);
        }

        SortCollection(Collection);
    }

    /// <summary>
    /// Refreshes collection by deleting all items and adding items again.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task RefreshCollection(ObservableCollection<TBaseModel> Collection, IEnumerable<TBaseModel> newItems)
    {
        IsRefreshing = true;

        Collection.Clear();

        foreach (var item in newItems)
            AddToCollection(Collection, item);

        SortCollection(Collection);

        IsRefreshing = false;
    }

    /// <summary>
    /// Deletes item from spcified Collection.
    /// </summary>
    /// <param name="Collection"></param>
    /// <param name="item"></param>
    protected virtual void RemoveFromCollection(ObservableCollection<TBaseModel> Collection, TBaseModel item) => Collection.Remove(item);

    /// <summary>
    /// Adds item to specified Collection.
    /// </summary>
    /// <param name="Collection"></param>
    /// <param name="item"></param>
    protected virtual void AddToCollection(ObservableCollection<TBaseModel> Collection, TBaseModel item) => Collection.Add(item);

    /// <summary>
    /// Edits item in specified Collection.
    /// </summary>
    /// <param name="Collection"></param>
    /// <param name="newItem"></param>
    /// <param name="oldItem"></param>
    protected virtual void EditInCollection(ObservableCollection<TBaseModel> Collection, TBaseModel newItem, TBaseModel oldItem) => Collection[Collection.IndexOf(oldItem)] = newItem;

    /// <summary>
    /// After updating or refreshing, list of Items is sorted by this function.
    /// </summary>
    protected virtual void SortCollection(ObservableCollection<TBaseModel> Collection) { }

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
    /// Task to perform when OpenItemCommand occurs.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected virtual async Task OpenItem(TBaseModel item) => await Shell.Current.GoToAsync($"{typeof(TItemView).Name}?Id={item.Id}");

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
        RemoveFromCollection(Items, item);
    }
   
    #endregion
}

