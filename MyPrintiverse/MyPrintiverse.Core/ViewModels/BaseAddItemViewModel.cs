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

    public string AddRoute => "..";

    #endregion

    public BaseAddItemViewModel(IMessageService messageService, IItemService<T> itemService) : base(messageService, itemService)
    {
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
                await OpenPage(AddRoute, true);
        
        IsRunning = false;
        IsBusy = false;
    }
    #endregion
}

