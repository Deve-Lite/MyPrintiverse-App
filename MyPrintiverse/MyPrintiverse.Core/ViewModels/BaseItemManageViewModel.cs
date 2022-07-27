using MyPrintiverse.Core.Services;
using MyPrintiverse.Core.Utilities;
using Plugin.ValidationRules;
using Plugin.ValidationRules.Interfaces;

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

    public BaseItemManageViewModel(IMessageService messageService, IItemService<T> itemService)
    {
        var itemServiceExceptionMessage = GetExceptionMessage<BaseEditItemViewModel<T>>(nameof(itemService));
        ItemService = itemService ?? throw new ArgumentNullException(itemServiceExceptionMessage);

        var messageServiceExceptionMessage = GetExceptionMessage<BaseEditItemViewModel<T>>(nameof(messageService));
        MessageService = messageService ?? throw new ArgumentNullException(messageServiceExceptionMessage);
    }

    /// <summary>
    /// Additional actions to perform when item is changed.
    /// </summary>
    protected virtual void OnChanged()
    {

    }
}
