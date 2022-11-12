using MyPrintiverse.Core.Services;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.ViewModels;

/// <summary>
/// Base view model for editing item.
/// <remarks> Id of item must be passed </remarks>
/// </summary>
/// <typeparam name="T"> Model. </typeparam>
[QueryProperty(nameof(Id), nameof(Id))]
public class BaseEditItemViewModel<T> : BaseFormViewModel<T> where T : BaseModel, new()
{
    #region Fields
    /// <summary>
    /// Item id used for quering,
    /// </summary>
    public string Id { get; set; }

    #endregion

    #region Routes

    public string EditRoute() => "..";

    #endregion

    public BaseEditItemViewModel(IMessageService messageService, IItemService<T> itemService) : base(messageService, itemService)
    {
    }

    #region Override

    public override void OnAppearing()
    {
        base.OnAppearing();
        //TO IMPLEMENT : LOADING
    }

    #endregion

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
                await OpenPage(EditRoute(), true);

        IsRunning = false;
        IsBusy = false;
    }

    #endregion
}

