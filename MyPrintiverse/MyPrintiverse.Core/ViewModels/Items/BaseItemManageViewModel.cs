using MyPrintiverse.Core.Items;
using MyPrintiverse.Core.Utilities;
using Plugin.ValidationRules;

namespace MyPrintiverse.Core.ViewModels.Items;

/// <summary>
/// View model for add / edit view.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseItemManageViewModel<T> : BaseViewModel where T : new()
{
    /// <summary>
    /// Item backing storage. 
    /// </summary>
    private Validatable<T> item; 

    /// <summary>
    /// Validatable item for stashing item data 
    /// </summary>
    public Validatable<T> Item { get => item; set => SetProperty(ref item, value, OnChanged); }

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
    /// Validation rule for item. (Item validation rule must be created)
    /// </summary>
    /// <exception cref="NotImplementedException"> Method must be implemented. </exception>
    protected virtual void AddValidation()
    {
        throw new NotImplementedException("Validation must be implemented.");
    }

    /// <summary>
    /// Method for item validation
    /// </summary>
    /// <returns></returns>
    protected virtual bool Validate()
    {
        return Item.Validate();
    }

    /// <summary>
    /// Actions to perform when item is changed.
    /// </summary>
    protected virtual void OnChanged()
    {

    }
}
