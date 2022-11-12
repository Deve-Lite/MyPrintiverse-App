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
public abstract partial class BaseFormViewModel<T> : BaseViewModel where T : BaseModel, new()
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
    /// Indicates is next step is validated.
    /// </summary>
    [ObservableProperty]
    public bool _nextIsRunning;

    /// <summary>
    /// Indicates moving to previous step.
    /// </summary>
    [ObservableProperty]
    public bool _previousIsRunning;


    /// <summary>
    /// Indicates actual step.
    /// </summary>
    [ObservableProperty]
    public int _step;

    /// <summary>
    /// Total steps to perform
    /// </summary>
    [ObservableProperty]
    public int _totalSteps;

    /// <summary>
    /// Description displayed in form header.
    /// </summary>
    [ObservableProperty]
    public string _stepDescription;

    /// <summary>
    /// Route to perform when back Button is clicked.
    /// </summary>
    public string BackRoute => "..";
    /// <summary>
    /// Route to perform after succesful add/edit action.
    /// </summary>
    public string SuccesRoute => "..";

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

    public BaseFormViewModel(IMessageService messageService, IItemService<T> itemService)
    {
        ItemService = itemService;
        MessageService = messageService;

        Step = 1;
        TotalSteps = 2;

        BackCommand = new AsyncRelayCommand(execute: Back, canExecute: CanExecute);
    }

    #region Overrides

    public override void OnAppearing()
    {
        base.OnAppearing();
    }

    #endregion

    #region Virtual Methods

    /// <summary>
    /// Performs add/edit to database action.
    /// </summary>
    /// <param name="manageItem"></param>
    /// <returns></returns>
    public virtual async Task ManageItem(Func<T, Task<bool>> manageItem)
    {
        if (AnyActionStartedCommand())
            return;

        IsRunning = true;

        if (IsValid())
            if (await manageItem.Invoke(Item.Map()))
                await OpenPage(SuccesRoute, true);

        IsRunning = false;
        IsBusy = false;
    }


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


    /// <summary>
    /// Set of standard actions for previous step.
    /// </summary>
    /// <param name="newStepDescription"></param>
    public virtual void DefaultPreviousStepAction(string newStepDescription) 
    {
        PreviousIsRunning = true;
        Task.Delay(DELAY);
        Step -= 1;
        StepDescription = newStepDescription;
        PreviousIsRunning = false;
    }

    /// <summary>
    /// Set of standard actions for next step.
    /// </summary>
    /// <param name="newStepDescription"></param>
    public virtual void DefaultNextStepAction(string newStepDescription, bool isValid) 
    {

        PreviousIsRunning = true;
        Task.Delay(DELAY);
        if (isValid)
        {
            Step += 1;
            StepDescription = newStepDescription;
        }

        PreviousIsRunning = false;
    }

    #endregion
}
