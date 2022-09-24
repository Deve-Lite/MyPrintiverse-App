using CommunityToolkit.Mvvm.ComponentModel;
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
public abstract partial class BaseItemManageViewModel<T> : BaseViewModel where T : BaseModel, new()
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

    /// <summary>
    /// Indicates if actual step is first one.
    /// </summary>
    [ObservableProperty]

    public bool _stepOne;
    /// <summary>
    /// Indicates if actual step is last one.
    /// </summary>
    [ObservableProperty]
    public bool _finishingStep;

    /// <summary>
    /// Text on next button.
    /// </summary>
    [ObservableProperty]
    public string _nextButtonTitle;

    public string BackRoute => "..";

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

        StepOne = true;
        FinishingStep = false;
        NextButtonTitle = "NEXT";

        BackCommand = new AsyncRelayCommand(execute: Back, canExecute: CanExecute);
    }

    #region Overrides

    public override void OnAppearing()
    {
        base.OnAppearing();
    }

    #endregion


    #region Virtual Methods
    public virtual async Task Back()
    {
        if (AnyActionStartedCommand())
            return;

        await Shell.Current.GoToAsync("..");
    }

    /// <summary>
    /// Returns whether data is valid.
    /// </summary>
    /// <returns></returns>
    public virtual bool IsValid() => Item.Validate();

    /// <summary>
    /// Returns whether first step if valid.
    /// </summary>
    /// <returns></returns>
    public virtual bool IsStepOneValid() => Item.Validate();

    /// <summary>
    /// Performs actions to move to next step.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public virtual Task StepBack() => throw new NotImplementedException("Implement this function for valid working.");

    /// <summary>
    /// Performs actions to load previously completed data.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public virtual Task NextStep() => throw new NotImplementedException("Implement this function for valid working.");

    #endregion
}
