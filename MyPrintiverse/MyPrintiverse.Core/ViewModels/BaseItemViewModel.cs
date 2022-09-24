using MyPrintiverse.Core.Utilities;
using MyPrintiverse.Core.Services;

namespace MyPrintiverse.Core.ViewModels;

/// <summary>
/// View Model for displaying Item with data.
/// </summary>
/// <remarks> Id of item must be passed </remarks>
/// <typeparam name="TBaseModel"> Model inheriting from BaseModel. </typeparam>
/// <typeparam name="TEdit"> Class (View) editing model. </typeparam>
[QueryProperty(nameof(Id), nameof(Id))]
public class BaseItemViewModel<TBaseModel, TEdit> : BaseViewModel where TBaseModel : BaseModel
{
    #region Fields

    /// <summary>
    /// Item backing storage.
    /// </summary>
    private TBaseModel item;

    /// <summary>
    /// Item with possibility to assign item properties in view.
    /// </summary>
    public TBaseModel Item { get => item; set => SetProperty(ref item, value); }

    /// <summary>
    /// Item id used for quering,
    /// </summary>
    public string Id { get; set; }

    protected virtual string EditRoute => $"{typeof(TEdit).Name}?Id={Item.Id}";
    protected virtual string DeleteRoute => "..";

    #endregion

    #region Commands
    /// <summary>
    /// Command for view, designed to open page with item edition.
    /// </summary>
    public AsyncRelayCommand EditItemCommand { get; }
    /// <summary>
    /// Command for view, designed to delete item.
    /// </summary>
    public AsyncRelayCommand DeleteItemCommand { get; }

    #endregion

    #region Services

    /// <summary>
    /// Service of item.
    /// </summary>
    protected IItemService<TBaseModel> ItemService { get; set; }

    /// <summary>
    /// Message service.
    /// </summary>
    protected IMessageService MessageService;

    #endregion

    public BaseItemViewModel(IMessageService messageService, IItemService<TBaseModel> itemService)
    {
        ItemService = itemService;
        MessageService = messageService;

        EditItemCommand = new AsyncRelayCommand(EditItem, CanExecute);
        DeleteItemCommand = new AsyncRelayCommand(DeleteItem, CanExecute);
    }

    #region Overrides
    public override void OnAppearing()
    {
        base.OnAppearing();

        Task.Run(async() => { Item = await ItemService.GetItemAsync(Id); });

    }

    #endregion

    #region Virtual Methods

    /// <summary>
    /// Task to perform with edit command.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task EditItem()
    {
        if (AnyActionStartedCommand())
            return;

        await OpenPage(EditRoute);
    }

    /// <summary>
    /// Task to perform with delete command.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task DeleteItem()
    {
        if (AnyActionStartedCommand())
            return;

        if (await MessageService.ShowSelectAlertAsync("Item Delete", "Do you really want to delete this item?", "Delete"))
            if (await ItemService.DeleteItemAsync(Id))
                await Shell.Current.GoToAsync(DeleteRoute, true);

        IsBusy = false;
    }

    #endregion

}
