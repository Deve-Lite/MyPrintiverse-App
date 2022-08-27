using MyPrintiverse.Core.Services;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.ViewModels;

/// <summary>
/// view model for adding item.
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
public class BaseAddItemViewModel<T> : BaseItemManageViewModel<T> where T : BaseModel, new()
{
    #region Commands

    /// <summary>
    /// Command for view, designed to save new item.
    /// </summary>
    public AsyncRelayCommand AddItemCommand { get; }

    #endregion

    public BaseAddItemViewModel(IMessageService messageService, IItemService<T> itemService) : base(messageService, itemService)
    {
        AddItemCommand = new AsyncRelayCommand(AddItem, CanExecute);
    }

    #region Virtual Methods

    /// <summary>
    /// Task to perform with add command.
    /// </summary>
    /// <returns></returns>
    public virtual async Task AddItem()
    {
        if (AnyActionStartedCommand())
            return;

        IsRunning = true;

        if (IsValid())
            if (await ItemService.AddItemAsync(Item.Map()))
                await Shell.Current.GoToAsync("..", true);
        
        IsRunning = false;
        IsBusy = false;
    }
    #endregion
}

