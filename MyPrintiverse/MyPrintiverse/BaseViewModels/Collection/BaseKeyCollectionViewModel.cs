namespace MyPrintiverse.BaseViewModels.Collection;

/// <summary>
/// Base ViewModel for view displaying collection with key service.
/// </summary>
/// <typeparam name="TBaseModel"> Model inheriting from BaseModel. </typeparam>
/// <typeparam name="TAdd"> Class (View) adding model.</typeparam>
/// <typeparam name="TEdit"> Class (View) editing model.</typeparam>
/// <typeparam name="TDisplay"> Class (View) displaying model.</typeparam>
[QueryProperty(nameof(Id), nameof(Id))]
public class BaseKeyCollectionViewModel<TBaseModel, TAdd, TEdit, TDisplay> : BaseCollectionViewModel<TBaseModel, TAdd, TEdit, TDisplay> where TBaseModel : BaseModel
{

    private string PrevId;
    public string Id { get; set; }

    protected IItemKeyAsyncService<TBaseModel> KeyItemsService;


    public BaseKeyCollectionViewModel(MessageService messagingService, IItemAsyncService<TBaseModel> itemsService, IItemKeyAsyncService<TBaseModel> keyItemsService) : base(messagingService, itemsService)
    {
        var keyItemServiceExceptionMessage = GetExceptionMessage<BaseKeyCollectionViewModel<TBaseModel, TAdd, TEdit, TDisplay>>(nameof(itemsService));
        KeyItemsService = keyItemsService ?? throw new ArgumentNullException(keyItemServiceExceptionMessage);
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


    protected override async Task UpdateItemsOnAppearing()
    {
        if (Id != PrevId)
            await RefreshItems();

        IsBusy = true;
        IsRefreshing = true;

        List<TBaseModel> data = (List<TBaseModel>)await KeyItemsService.GetItemsByKeyAsync(Id);

        int i = 0;
        foreach (TBaseModel item in new List<TBaseModel>(Items))
        {
            TBaseModel newItem = data.First(x => x.Id == item.Id);

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

    protected override async Task RefreshItems()
    {

        IsRefreshing = true;

        Items.Clear();

        foreach (var item in await KeyItemsService.GetItemsByKeyAsync(Id))
            Items.Add(item);

        IsBusy = false;
        IsRefreshing = false;
    }


}
