


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

    #endregion

    #region Commands
    /// <summary>
    /// Command for view, designed to open page with item edition.
    /// </summary>
    public AsyncCommand EditItemCommand { get; set; }
    /// <summary>
    /// Command for view, designed to delete item.
    /// </summary>
    public AsyncCommand DeleteItemCommand { get; set; }

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

        EditItemCommand = new AsyncCommand(EditItem, CanExecute, shellExecute: ExecuteBlockade);
        DeleteItemCommand = new AsyncCommand(DeleteItem, CanExecute, shellExecute: ExecuteBlockade);
    }

    #region Overrides
    public override async void OnAppearing()
    {
        base.OnAppearing();

        Item = await ItemService.GetItemAsync(Id);
    }

    #endregion

    #region Virtual Methods

    /// <summary>
    /// Task to perform with edit command.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task EditItem() => await Shell.Current.GoToAsync($"{typeof(TEdit).Name}");

    /// <summary>
    /// Task to perform with delete command.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task DeleteItem()
    {
        if (!(await MessageService.ShowSelectAlertAsync("Item Delete", "Do you really want to delete this item?", "Delete")))
            return;

        if (await ItemService.DeleteItemAsync(Id))
            await Shell.Current.GoToAsync("..", true);
    }

    #endregion

}
