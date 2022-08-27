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
    #region Fields
    /// <summary>
    /// Item id used for quering,
    /// </summary>
    public string Id { get; set; }

    #endregion

    #region Commands

    /// <summary>
    /// Command for view, designed to save edited item.
    /// </summary>
    public AsyncRelayCommand EditItemCommand { get; }

    #endregion

    public BaseEditItemViewModel(IMessageService messageService, IItemService<T> itemService) : base(messageService, itemService)
    {
        EditItemCommand = new AsyncRelayCommand(EditItem, CanExecute);
    }

    #region Virtual Methods

    /// <summary>
    /// Task to perform with edit command.
    /// </summary>
    /// <returns></returns>
    public virtual async Task EditItem()
    {
        if (AnyActionStartedCommand())
            return;

        IsRunning = true;

        if (IsValid())
            if (await ItemService.UpdateItemAsync(Item.Map()))
                await Shell.Current.GoToAsync("..", true);

        IsRunning = false;
        IsBusy = false;
    }

    #endregion
}

