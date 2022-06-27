using MyPrintiverse.BaseModels;
using Plugin.ValidationRules;

namespace MyPrintiverse.BaseViewModels.Item;

/// <summary>
/// Base view model for adding new item.
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
public class BaseAddItemViewModel<T> : BaseViewModel where T : new()
{
    private Validatable<T> item;
    public Validatable<T> Item { get => item; set => SetProperty(ref item, value, OnChanged); }

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

        Item.Value = new T();
        AddItemCommand = new AsyncCommand(AddItem, CanExecute);
        AddValidation();
    }

    protected virtual void AddValidation()
    {
        throw new NotImplementedException("Validation must be implemented.");
    }

    protected virtual bool Validate()
    {
        return Item.Validate();
    }

    public virtual async Task AddItem()
    {
        // Open loading popup/ activity indicator

        if (await ItemService.AddItemAsync(Item.Value))
            await Shell.Current.GoToAsync("..", true);


        IsBusy = false;
    }

    protected virtual void OnChanged()
    {

    }
}

