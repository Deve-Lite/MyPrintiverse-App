using MyPrintiverse.Core.Items;
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
    /// <summary>
    /// Base collection of TBaseModel.
    /// </summary>
    public ObservableCollection<TBaseModel> Items { get; set; }

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

    /// <summary>
    /// Collection service.
    /// </summary>
    protected IItemService<TBaseModel> ItemsService;
    /// <summary>
    /// Message service.
    /// </summary>
    protected IMessageService MessageService;

    public BaseCollectionViewModel(IMessageService messageService, IItemService<TBaseModel> itemsService)
    {
        var messageServiceExceptionMessage = GetExceptionMessage<BaseCollectionViewModel<TBaseModel, TAddView, TEditView, TItemView>>(nameof(messageService));
        MessageService = messageService ?? throw new ArgumentNullException(messageServiceExceptionMessage);

        var itemsServiceExceptionMessage = GetExceptionMessage<BaseCollectionViewModel<TBaseModel, TAddView, TEditView, TItemView>>(nameof(itemsService));
        ItemsService = itemsService ?? throw new ArgumentNullException(itemsServiceExceptionMessage);

        Items = new ObservableCollection<TBaseModel>();
    }

    protected internal override async void OnAppearing()
    {
        base.OnAppearing();


        RefreshItemsCommand = new AsyncCommand(RefreshItems, CanExecute);
        AddItemCommand = new AsyncCommand(AddItem, CanExecute);
        EditItemCommand = new AsyncCommand<TBaseModel>(EditItem, CanExecute);
        OpenItemCommand = new AsyncCommand<TBaseModel>(OpenItem, CanExecute);
        DeleteItemCommand = new AsyncCommand<TBaseModel>(DeleteItem, CanExecute);

        await UpdateItemsOnAppearing();
    }

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

        IsBusy = false;
    }

    /// <summary>
    /// Task to perform when AddItemCommand occurs.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task AddItem() => await Shell.Current.GoToAsync($"{typeof(TAddView).Name}");

    /// <summary>
    /// Task to perfrom when page is loading, designed for refresh collection with new data.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task UpdateItemsOnAppearing()
    {
        IsBusy = true;
        IsRefreshing = true;

        var data = (List<TBaseModel>)await ItemsService.GetItemsAsync();

        int i = 0;
        foreach (var item in new List<TBaseModel>(Items))
        {
            var newItem = data.First(x => x.Id == item.Id);

            if (newItem == null)
            {
                Items.Remove(item);
                data.Remove(item);
            }
            else if (item.EditedAt == newItem.EditedAt)
            {
                Items[Items.IndexOf(item)] = newItem;
                data.Remove(item);
            }
        }

        foreach (TBaseModel item in data)
            Items.Add(item);

        IsRefreshing = false;
        IsBusy = false;
    }

    /// <summary>
    /// Task to perform when RefreshItemsCommand occurs.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task RefreshItems()
    {

        IsRefreshing = true;

        Items.Clear();

        foreach (var item in await ItemsService.GetItemsAsync())
            Items.Add(item);

        IsBusy = false;
        IsRefreshing = false;
    }

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

        if (await ItemsService.DeleteItemAsync(item.Id))
            Items.Remove(item);

        IsBusy = false;
    }

    /// <summary>
    /// Task to perform when OpenItemCommand occurs.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected virtual async Task OpenItem(TBaseModel item) => await Shell.Current.GoToAsync($"{typeof(TItemView).Name}?Id={item.Id}");
}

