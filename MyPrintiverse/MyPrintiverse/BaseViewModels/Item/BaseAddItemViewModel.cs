using MyPrintiverse.BaseModels;

namespace MyPrintiverse.BaseViewModels.Item;

/// <summary>
/// Base view model for adding new item.
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
public class BaseAddItemViewModel<T> : BaseViewModel
{
    private T item;
    public T Item { get => item; set => SetProperty(ref item, value, OnChanged); }

    public AsyncCommand AddItemCommand { get; set; }

    protected IItemAsyncService<T> ItemService;

    public BaseAddItemViewModel(IItemAsyncService<T> itemService)
{
        var itemServiceExceptionMessage = GetExceptionMessage<BaseAddItemViewModel<T>>(nameof(itemService));
        ItemService = itemService ?? throw new ArgumentNullException(itemServiceExceptionMessage);
    }

    protected internal override void OnAppearing()
    {
        base.OnAppearing();

        AddItemCommand = new AsyncCommand(AddItem, CanExecute);
    }



    public virtual async Task AddItem()
    {
        // Open loading popup/ activity indicator

        if (await ItemService.AddItemAsync(Item))
            await Shell.Current.GoToAsync("..", true);


        IsBusy = false;
    }

    protected virtual void OnChanged()
    {

    }
}

