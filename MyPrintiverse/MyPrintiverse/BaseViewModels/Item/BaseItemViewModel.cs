﻿namespace MyPrintiverse.BaseViewModels.Item;

/// <summary>
/// View Model for displaying Item with data.
/// </summary>
/// <remarks> Id of item must be passed </remarks>
/// <typeparam name="TBaseModel"> Model inheriting from BaseModel. </typeparam>
/// <typeparam name="TEdit"> Class (View) editing model. </typeparam>
[QueryProperty(nameof(Id), nameof(Id))]
public class BaseItemViewModel<TBaseModel, TEdit> : BaseViewModel where TBaseModel : BaseModel
{
    /// <summary>
    /// Item backing storage.
    /// </summary>
    private TBaseModel item;

    /// <summary>
    /// Item with possibility to assign item properties in view.
    /// </summary>
    public TBaseModel Item { get => item; set => SetProperty(ref item, value); }

    /// <summary>
    /// Command for view, designed to open page with item edition.
    /// </summary>
    public AsyncCommand EditItemCommand { get; set; }
    /// <summary>
    /// Command for view, designed to delete item.
    /// </summary>
    public AsyncCommand DeleteItemCommand { get; set; }

    /// <summary>
    /// Item id used for quering,
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Service of item.
    /// </summary>
    protected IItemService<TBaseModel> ItemService { get; set; }

    public BaseItemViewModel(IItemService<TBaseModel> itemService)
{
        var itemServiceExceptionMessage = GetExceptionMessage<BaseItemViewModel<TBaseModel, TEdit>>(nameof(itemService));
        ItemService = itemService ?? throw new ArgumentNullException(itemServiceExceptionMessage);
    }


    protected internal override async void OnAppearing()
    {
        base.OnAppearing();

        EditItemCommand = new AsyncCommand(EditItem, CanExecute);
        DeleteItemCommand = new AsyncCommand(DeleteItem, CanExecute);

        Item = await ItemService.GetItemAsync(Id);
    }

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
        // make sure about 

        if (await ItemService.DeleteItemAsync(Id))
            await Shell.Current.GoToAsync("..", true);

        IsBusy = false;
    }

}
