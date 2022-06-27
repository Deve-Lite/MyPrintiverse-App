using MyPrintiverse.BaseModels;
using Plugin.ValidationRules;

namespace MyPrintiverse.BaseViewModels.Item;

/// <summary>
/// Base view model for editing any item.
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
[QueryProperty(nameof(Id), nameof(Id))]
public class BaseEditItemViewModel<T> : BaseViewModel
{
    public string Id { get; set; }

    private Validatable<T> item;
    public Validatable<T> Item { get => item; set => SetProperty(ref item, value, OnChanged); }

    public AsyncCommand EditItemCommand { get; set; }

    protected IItemAsyncService<T> ItemService;

    public BaseEditItemViewModel(IItemAsyncService<T> itemService)
{
        var itemServiceExceptionMessage = GetExceptionMessage<BaseEditItemViewModel<T>>(nameof(itemService));
        ItemService = itemService ?? throw new ArgumentNullException(itemServiceExceptionMessage);
    }

    protected internal override async void OnAppearing()
    {
        base.OnAppearing();

        Item.Value = await ItemService.GetItemAsync(Id);

        EditItemCommand = new AsyncCommand(EditItem, CanExecute);
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

    public virtual async Task EditItem()
    {

        // Open loading popup / activity indicator

        if (await ItemService.UpdateItemAsync(Item.Value))
            await Shell.Current.GoToAsync("..", true);


        IsBusy = false;
    }

    protected virtual void OnChanged()
    {

    }
}

