using MyPrintiverse.Core.Services;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.ViewModels;

/// <summary>
/// View model for add / edit view.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseItemManageViewModel<T> : BaseViewModel where T : BaseModel, new() 
{
    /// <summary>
    /// Item backing storage. 
    /// </summary>
    private IMapperValidator<T> item;

    /// <summary>
    /// Validatable item for stashing item data 
    /// </summary>
    public IMapperValidator<T> Item { get => item; set => SetProperty(ref item, value, OnChanged); }

    /// <summary>
    /// Service of item.
    /// </summary>
    protected IItemService<T> ItemService;

    /// <summary>
    /// Message service.
    /// </summary>
    protected IMessageService MessageService;

    /// <summary>
    /// Command designed to go to previous page.
    /// </summary>
    public AsyncCommand? BackCommand { get; set; }

    public BaseItemManageViewModel(IMessageService messageService, IItemService<T> itemService)
    {
        var itemServiceExceptionMessage = GetExceptionMessage<BaseEditItemViewModel<T>>(nameof(itemService));
        ItemService = itemService ?? throw new ArgumentNullException(itemServiceExceptionMessage);

        var messageServiceExceptionMessage = GetExceptionMessage<BaseEditItemViewModel<T>>(nameof(messageService));
        MessageService = messageService ?? throw new ArgumentNullException(messageServiceExceptionMessage);
    }

    public override void OnAppearing()
    {
        base.OnAppearing();

        BackCommand = new AsyncCommand(Back);
    }


    public virtual async Task Back() => await Shell.Current.GoToAsync("..");

    /// <summary>
    /// Additional actions to perform when item is changed.
    /// </summary>
    public virtual void OnChanged()
    {

    }
}
