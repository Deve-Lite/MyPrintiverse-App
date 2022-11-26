using MyPrintiverse.Core.Services;
using MyPrintiverse.Core.Utilities;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

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
    protected List<TBaseModel> Items { get; set; }

    /// <summary>
    /// Searched collection of Items.
    /// </summary>
    public ObservableCollection<TBaseModel> SearchedItems { get; set; }

    #endregion

    #region Commands

    /// <summary>
    /// Command for refreshing collection.
    /// </summary>
    public AsyncRelayCommand RefreshCommand { get; }

    /// <summary>
    /// Command for adding new item to collection.
    /// </summary>
    public AsyncRelayCommand AddItemCommand { get; }

    /// <summary>
    /// Command for displaying multiple manage options for collection item. 
    /// </summary>
    public AsyncRelayCommand<TBaseModel> ItemOptionsCommand { get; }

    /// <summary>
    /// Command for displaying single item from collection.
    /// </summary>
    public AsyncRelayCommand<TBaseModel> OpenItemCommand { get; }

    /// <summary>
    /// Command for deleting one item from collection.
    /// </summary>
    public AsyncRelayCommand<TBaseModel> DeleteItemCommand { get; }

    /// <summary>
    /// Command for editing one item from collection.
    /// </summary>
    public AsyncRelayCommand<TBaseModel> EditItemCommand { get; }

    /// <summary>
    /// Searches items in collection.
    /// </summary>
    public RelayCommand<string> SearchItemsCommand { get; }


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

    #region Properties

    protected virtual string EditRoute(TBaseModel item) => $"{typeof(TEditView).Name}?Id={item.Id}";
    protected virtual string OpenRoute(TBaseModel item) => $"{typeof(TItemView).Name}?Id={item.Id}";
    protected virtual string AddRoute() => $"{typeof(TAddView).Name}";

    #endregion

    public BaseCollectionViewModel(IMessageService messageService, IItemService<TBaseModel> itemsService)
    {
        MessageService = messageService;
        ItemsService = itemsService;

        Items = new List<TBaseModel>();
        SearchedItems = new ObservableCollection<TBaseModel>();

        RefreshCommand = new AsyncRelayCommand(Refresh, CanExecute);
        AddItemCommand = new AsyncRelayCommand(AddItem, CanExecute);
        EditItemCommand = new AsyncRelayCommand<TBaseModel>(EditItem, CanExecute);
        OpenItemCommand = new AsyncRelayCommand<TBaseModel>(OpenItem, CanExecute);
        DeleteItemCommand = new AsyncRelayCommand<TBaseModel>(DeleteItem, CanExecute);
        ItemOptionsCommand = new AsyncRelayCommand<TBaseModel>(ItemOptions, CanExecute);
        SearchItemsCommand = new RelayCommand<string>(SearchItems);
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
        Items = (List<TBaseModel>)await ItemsService.GetItemsAsync();

        UpdateCollection(SearchedItems, Items);
    }

    /// <summary>
    /// Task to perform when RefreshCommand occurs.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task Refresh() 
    {
        Items = (List<TBaseModel>)await ItemsService.GetItemsAsync();
        RefreshCollection(SearchedItems, Items);
    }


    #endregion

    #region Collection

    protected virtual void SearchItems(string query)
    {
        var filteredItems = Items.Where(item => MatchQuery(item, query));

        foreach(TBaseModel item in Items) 
        {
            if (!filteredItems.Contains(item))
                SearchedItems.Remove(item);
            else if (!Items.Contains(item))
                SearchedItems.Add(item);
        }
    }


    protected virtual bool MatchQuery(TBaseModel item,string query) 
    {
        throw new NotImplementedException("Match query must be implemented.");
    }

    /// <summary>
    /// Updates colection with new items and deletes items that not occure in items.
    /// </summary>
    /// <param name="collection"> Collction to update. </param>
    /// <param name="items"> Items for collection update. </param>
    /// <param name="addRemaingItems"> Terminates if elements left in items are automatically added to collection. </param>
    /// <returns></returns>
    protected virtual void UpdateCollection(ObservableCollection<TBaseModel> collection, List<TBaseModel> items, bool addRemaingItems = true)
    {
        foreach (var oldItem in new List<TBaseModel>(collection))
        {
            var newItem = items.FirstOrDefault(x => x.Id == oldItem.Id);

            if (newItem == null)
            {
                RemoveFromCollection(collection, oldItem);
            }
            else if (oldItem.EditedAt != newItem.EditedAt)
            {
                EditInCollection(collection, newItem, oldItem);
                items.Remove(newItem);
            }
            else if (newItem.EditedAt == oldItem.EditedAt)
                items.Remove(newItem);
        }

        if (addRemaingItems)
        {
            foreach (TBaseModel item in items)
                AddToCollection(collection, item);
        }

        SortCollection(collection);
    }

    /// <summary>
    /// Refreshes collection by clearing collection and adding items again.
    /// </summary>
    /// <param name="collection"> Collection to refresh. </param>
    /// <param name="items"> Items to add to Collection. </param>
    /// <param name="notifyCollection"> Terminate to notify RefreshView about refresh. </param>
    /// <returns></returns>
    protected virtual void RefreshCollection(ObservableCollection<TBaseModel> collection, IEnumerable<TBaseModel> items, bool notifyCollection = true)
    {
        if(notifyCollection)
            IsRefreshing = true;

        collection.Clear();

        foreach (var item in items)
            AddToCollection(collection, item);

        SortCollection(collection);

        if (notifyCollection)
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
    protected virtual async Task ItemOptions(TBaseModel? item)
    {

        var action = await MessageService.ShowActionSheetAsync<BaseItemActions>("Actions:");

        if (action == BaseItemActions.Open)
            await OpenPage(OpenRoute(item));
        else if (action == BaseItemActions.Delete)
        {
            if (await MessageService.ShowSelectAlertAsync("Item Delete", "Do you really want to delete this item?", "Delete"))
                if (await ItemsService.DeleteItemAsync(item?.Id))
                    DeleteFromSearchedItems(item);


            IsBusy = false;
        }
        else if (action == BaseItemActions.Edit)
            await OpenPage(EditRoute(item));
    }

    /// <summary>
    /// Task to perform when AddItemCommand occurs.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task AddItem()
    {
        if (AnyActionStartedCommand())
            return;

        await OpenPage(AddRoute());

        IsBusy = false;
    }

    /// <summary>
    /// Task to perform when EditItemCommand occurs.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected virtual async Task EditItem(TBaseModel? item)
    {
        if (AnyActionStartedCommand())
            return;

        await OpenPage(EditRoute(item));


        IsBusy = false;
    }

    /// <summary>
    /// Task to perform when OpenItemCommand occurs.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected virtual async Task OpenItem(TBaseModel? item) 
    {
        if (AnyActionStartedCommand())
            return;

        await OpenPage(OpenRoute(item));


        IsBusy = false;
    }

    /// <summary>
    /// Task to perform when DeleteItemCommand occurs.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected virtual async Task DeleteItem(TBaseModel? item)
    {
        if (AnyActionStartedCommand())
            return;

        if (await MessageService.ShowSelectAlertAsync("Item Delete", "Do you really want to delete this item?", "Delete"))
            if (await ItemsService.DeleteItemAsync(item!.Id))
                DeleteFromSearchedItems(item);

        IsBusy = false;
    }

    /// <summary>
    /// Method deletes item from collection. Method used in DeleteItem.
    /// </summary>
    /// <param name="item"> Model. </param>
    protected virtual void DeleteFromSearchedItems(TBaseModel? item) => RemoveFromCollection(SearchedItems, item!);

    #endregion

}

