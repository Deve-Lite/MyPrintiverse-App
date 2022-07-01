using MyPrintiverse.BaseModels;
using Plugin.ValidationRules;

namespace MyPrintiverse.BaseViewModels.Item;

/// <summary>
/// Base view model for editing item.
/// <remarks> Id of item must be passed </remarks>
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
[QueryProperty(nameof(Id), nameof(Id))]
public class BaseEditItemViewModel<T> : BaseItemManageViewModel<T> where T : new()
{ 

    /// <summary>
    /// Item id used for quering,
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Command for view, designed to save edited item.
    /// </summary>
    public AsyncCommand EditItemCommand { get; set; }

    public BaseEditItemViewModel(IMessageService messageService, IItemService<T> itemService) : base(messageService, itemService)
    {
    }

    protected internal override async void OnAppearing()
    {
        base.OnAppearing();

        Item.Value = await ItemService.GetItemAsync(Id);

        EditItemCommand = new AsyncCommand(EditItem, CanExecute);
        AddValidation();
    }

    /// <summary>
    /// Task to perform with edit command.
    /// </summary>
    /// <returns></returns>
    public virtual async Task EditItem()
    {
        // Open loading popup / activity indicator

        if (await ItemService.UpdateItemAsync(Item.Value))
            await Shell.Current.GoToAsync("..", true);


        IsBusy = false;
    }

}

