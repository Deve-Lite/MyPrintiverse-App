using MyPrintiverse.BaseModels;
using Plugin.ValidationRules;

namespace MyPrintiverse.BaseViewModels.Item;

/// <summary>
/// Base view model for editing any item.
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
[QueryProperty(nameof(Id), nameof(Id))]
public class BaseEditItemViewModel<T> : BaseItemManageViewModel<T>
{
    public string Id { get; set; }

    public AsyncCommand EditItemCommand { get; set; }

    public BaseEditItemViewModel(IItemAsyncService<T> itemService) : base(itemService)
    {
    }

    protected internal override async void OnAppearing()
    {
        base.OnAppearing();

        Item.Value = await ItemService.GetItemAsync(Id);

        EditItemCommand = new AsyncCommand(EditItem, CanExecute);
        AddValidation();
    }

    public virtual async Task EditItem()
    {
        // Open loading popup / activity indicator

        if (await ItemService.UpdateItemAsync(Item.Value))
            await Shell.Current.GoToAsync("..", true);


        IsBusy = false;
    }

}

