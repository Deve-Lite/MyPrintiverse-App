using MyPrintiverse.Core.Services;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.ViewModels;

/// <summary>
/// Base view model for editing item.
/// <remarks> Id of item must be passed </remarks>
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
[QueryProperty(nameof(Id), nameof(Id))]
public class BaseEditItemViewModel<T> : BaseItemManageViewModel<T> where T : BaseModel, new()
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
        EditItemCommand = new AsyncCommand(EditItem, CanExecute, shellExecute: ExecuteBlockade);
    }

    public override async void OnAppearing() => base.OnAppearing();

    /// <summary>
    /// Task to perform with edit command.
    /// </summary>
    /// <returns></returns>
    public virtual async Task EditItem()
    {
        IsRunning = true;

        if (!IsValid())
        {
            IsRunning = false;
            return;
        }

        if (await ItemService.UpdateItemAsync(Item.Map()))
            await Shell.Current.GoToAsync("..", true);

        IsRunning = false;  
    }

}

