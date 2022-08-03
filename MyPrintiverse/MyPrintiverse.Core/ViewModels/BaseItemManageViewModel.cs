using MyPrintiverse.Core.Services;
using MyPrintiverse.Core.Utilities;
using Plugin.ValidationRules;

namespace MyPrintiverse.Core.ViewModels;

/// <summary>
/// View model for add / edit view.
/// </summary>
/// <typeparam name="T"></typeparam>
/// 
/// zmiana na T i TValidataor
public abstract class BaseItemManageViewModel<T> : BaseViewModel where T : BaseModel, new() 
{
    #region Fields
    /// <summary>
    /// Item backing storage. 
    /// </summary>
    private Validator<T> item;

    /// <summary>
    /// Validatable item for stashing item data 
    /// </summary>
    public Validator<T> Item { get => item; set => SetProperty(ref item, value, OnChanged); }

    #endregion

    #region Services

    /// <summary>
    /// Service of item.
    /// </summary>
    protected IItemService<T> ItemService;

    /// <summary>
    /// Message service.
    /// </summary>
    protected IMessageService MessageService;

    #endregion

    #region Commands

    /// <summary>
    /// Command designed to go to previous page.
    /// </summary>
    public AsyncCommand? BackCommand { get; set; }

    #endregion

    public BaseItemManageViewModel(IMessageService messageService, IItemService<T> itemService)
    {
        var itemServiceExceptionMessage = GetExceptionMessage<BaseEditItemViewModel<T>>(nameof(itemService));
        ItemService = itemService ?? throw new ArgumentNullException(itemServiceExceptionMessage);

        var messageServiceExceptionMessage = GetExceptionMessage<BaseEditItemViewModel<T>>(nameof(messageService));
        MessageService = messageService ?? throw new ArgumentNullException(messageServiceExceptionMessage);

        BackCommand = new AsyncCommand(Back, CanExecute, shellExecute: ExecuteBlockade);
    }

    #region Virtual Methods
    public virtual async Task Back() => await Shell.Current.GoToAsync("..");

    /// <summary>
    /// Additional actions to perform when item is changed.
    /// </summary>
    public virtual void OnChanged()
    {

    }

    public virtual bool IsValid()
    {
        return Item.Validate();
    }

    #endregion
}
