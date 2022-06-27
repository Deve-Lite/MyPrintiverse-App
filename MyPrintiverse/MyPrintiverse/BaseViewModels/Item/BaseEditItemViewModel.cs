using MyPrintiverse.BaseModels;

namespace MyPrintiverse.BaseViewModels.Item;

/// <summary>
/// Base view model for editing any item.
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
[QueryProperty(nameof(Id), nameof(Id))]
public class BaseEditItemViewModel<T> : BaseViewModel
{
    public string Id { get; set; }

    private T item;
    public T Item { get => item; set => SetProperty(ref item, value, OnChanged); }

    public AsyncCommand AddItemCommand { get; set; }

    protected IItemAsyncService<T> ItemService;

    public BaseEditItemViewModel(IItemAsyncService<T> itemService)
{
        var itemServiceExceptionMessage = GetExceptionMessage<BaseEditItemViewModel<T>>(nameof(itemService));
        ItemService = itemService ?? throw new ArgumentNullException(itemServiceExceptionMessage);
    }

    protected internal override async void OnAppearing()
    {
        base.OnAppearing();

        Item = await ItemService.GetItemAsync(Id);

        AddItemCommand = new AsyncCommand(EditItem, CanExecute);
    }


    public virtual async Task EditItem()
    {

        // Open loading popup / activity indicator

        if (await ItemService.UpdateItemAsync(Item))
            await Shell.Current.GoToAsync("..", true);


        IsBusy = false;
    }

    protected virtual void OnChanged()
    {

    }
}

