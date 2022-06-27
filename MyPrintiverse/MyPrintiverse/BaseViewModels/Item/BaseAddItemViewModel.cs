using MyPrintiverse.BaseModels;
using Plugin.ValidationRules;

namespace MyPrintiverse.BaseViewModels.Item;

/// <summary>
/// Base view model for adding new item.
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
public class BaseAddItemViewModel<T> : BaseItemManageViewModel<T> where T : new()
{
    public AsyncCommand AddItemCommand { get; set; }

    public BaseAddItemViewModel(IItemAsyncService<T> itemService) : base(itemService)
    {
    }

    protected internal override void OnAppearing()
    {
        base.OnAppearing();

        Item.Value = new T();
        AddItemCommand = new AsyncCommand(AddItem, CanExecute);
       
        AddValidation();
    }

    public virtual async Task AddItem()
    {
        // Open loading popup/ activity indicator

        if (await ItemService.AddItemAsync(Item.Value))
            await Shell.Current.GoToAsync("..", true);


        IsBusy = false;
    }
}

