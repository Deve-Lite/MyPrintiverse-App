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
    public Validator<T> Item { get => item; set => SetProperty(ref item, value); }

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
    public AsyncRelayCommand BackCommand { get; }

    #endregion

    public BaseItemManageViewModel(IMessageService messageService, IItemService<T> itemService)
    {
        ItemService = itemService;
        MessageService = messageService;

        BackCommand = new AsyncRelayCommand(execute: Back, canExecute: CanExecute);
    }

    #region Virtual Methods
    public virtual async Task Back()
    {
        if (AnyActionStartedCommand())
            return;

        await Shell.Current.GoToAsync("..");
    }

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
