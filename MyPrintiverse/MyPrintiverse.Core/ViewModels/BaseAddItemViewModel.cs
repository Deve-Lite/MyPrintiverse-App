using MyPrintiverse.Core.Services;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.ViewModels;

/// <summary>
/// view model for adding item.
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
public class BaseAddItemViewModel<T> : BaseItemManageViewModel<T> where T : new()
{
    /// <summary>
    /// Command for view, designed to save new item.
    /// </summary>
    public AsyncCommand? AddItemCommand { get; set; }

    public BaseAddItemViewModel(IMessageService messageService, IItemService<T> itemService) : base(messageService, itemService)
    {
    }

    public override void OnAppearing()
    {
        base.OnAppearing();

        Item.Value = new T();

        AddItemCommand = new AsyncCommand(AddItem, CanExecute, shellExecute: ExecuteBlockade);

        AddValidation();
    }

    /// <summary>
    /// Task to perform with add command.
    /// </summary>
    /// <returns></returns>
    public virtual async Task AddItem()
    {
        // TODO activity button

        if (await ItemService.AddItemAsync(Item.Value))
            await Shell.Current.GoToAsync("..", true);

    }
}

