using Plugin.ValidationRules;

namespace MyPrintiverse.BaseViewModels.Item;

/// <summary>
/// Base model for add / edit view.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseItemManageViewModel<T> : BaseViewModel where T : new()
{
    private Validatable<T> item;
    public Validatable<T> Item { get => item; set => SetProperty(ref item, value, OnChanged); }

    public AsyncCommand EditItemCommand { get; set; }

    protected IItemAsyncService<T> ItemService;

    public BaseItemManageViewModel(IItemAsyncService<T> itemService)
    {
        var itemServiceExceptionMessage = GetExceptionMessage<BaseEditItemViewModel<T>>(nameof(itemService));
        ItemService = itemService ?? throw new ArgumentNullException(itemServiceExceptionMessage);
    }

    /// <summary>
    /// You just need to create 1 Validation Rule for obiect or you can set all needed validation rules for object.
    /// Method must be implemented.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    protected virtual void AddValidation()
    {
        throw new NotImplementedException("Validation must be implemented.");
    }

    protected virtual bool Validate()
    {
        return Item.Validate();
    }

    protected virtual void OnChanged()
    {

    }
}
