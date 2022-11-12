
using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.Tools;

namespace MyPrintiverse.FilamentsModule.Types;

public abstract partial class TypeFormViewModel : BaseFormViewModel<FilamentType>
{
    #region Properties

    [ObservableProperty]
    private string _nozzleError;
    [ObservableProperty]
    private string _coolingError;
    [ObservableProperty]
    private string _bedError;

    #endregion

    #region Services

    protected IToast Toast;

    #endregion

    protected TypeFormViewModel(IMessageService messageService, IItemService<FilamentType> itemService, IToast toast) : base(messageService, itemService)
    {
        Item = new FilamentTypeValidator();
        Toast = toast;
        TotalSteps = 4;
        StepDescription = "TODO 1";
    }

    #region Overrides

    [RelayCommand]
    public override async Task StepBack()
    {
        //TODO: Simulate Data Animation
        await Task.Delay(500);

        if (Step == 2)
        {
            DefaultPreviousStepAction("TODO 1");
        }

        if (Step == 3)
        {
            DefaultPreviousStepAction("TODO 2"); 
        }

        if (Step == 4)
        {
            DefaultPreviousStepAction("TODO 3");
        }

    }

    public override bool IsStepOneValid() => (Item as FilamentTypeValidator).ShortName.Validate() &&
                                             (Item as FilamentTypeValidator).FullName.Validate() &&
                                             (Item as FilamentTypeValidator).Description.Validate();

    #endregion

    #region Protected

    [RelayCommand]
    protected void NozzleValidate()
    {
        var item = (Item as FilamentTypeValidator);
        var isMinValid = item!.NozzleMin.Validate();
        var isMaxValid = item!.NozzleMax.Validate();

        if (!isMinValid)
            NozzleError = item!.NozzleMin.Error;

        if (!string.IsNullOrEmpty(item.NozzleMax.Value))
            if (!item!.NozzleMax.Validate() && isMinValid)
                    NozzleError = item!.NozzleMax.Error;

        if (isMinValid && isMaxValid)
            NozzleError = "";
    }

    [RelayCommand]
    protected void BedValidate()
    {
        var item = (Item as FilamentTypeValidator);
        var isMinValid = item!.BedMin.Validate();
        var isMaxValid = item!.BedMax.Validate();

        if (!isMinValid)
            BedError = item!.BedMin.Error;

        if (!string.IsNullOrEmpty(item.BedMax.Value))
            if (!item!.BedMax.Validate() && isMinValid)
                BedError = item!.BedMax.Error;

        if (isMinValid && isMaxValid)
            BedError = "";
    }

    [RelayCommand]
    protected void CoolingValidate()
    {
        var item = (Item as FilamentTypeValidator);
        var isMinValid = item!.CoolingMin.Validate();
        var isMaxValid = item!.CoolingMax.Validate();

        if (!isMinValid)
            CoolingError = item!.CoolingMin.Error;

        if (!string.IsNullOrEmpty(item.CoolingMax.Value))
            if (!item!.CoolingMax.Validate() && isMinValid)
                CoolingError = item!.CoolingMax.Error;

        if (isMinValid && isMaxValid)
            CoolingError = "";
    }


    protected virtual bool IsStepTwoValid() => (Item as FilamentTypeValidator).Density.Validate() &&
                                               (Item as FilamentTypeValidator).MaxServiceTempearature.Validate() &&
                                               (Item as FilamentTypeValidator).NozzleMin.Validate() &&
                                               (Item as FilamentTypeValidator).NozzleMax.Validate() &&
                                               (Item as FilamentTypeValidator).BedMin.Validate() &&
                                               (Item as FilamentTypeValidator).BedMax.Validate() &&
                                               (Item as FilamentTypeValidator).CoolingMin.Validate() &&
                                               (Item as FilamentTypeValidator).CoolingMax.Validate();
    protected virtual bool IsStepThreeValid() => true;

    protected async Task Next(Func<Task> manageItem)
    {
        IsRunning = true;

        //TODO: Simulate Data Animation
        await Task.Delay(500);

        if (Step == 4)
        {
            await manageItem.Invoke();
        }

        if (Step == 3)
        {
            NextIsRunning = true;
            await Task.Delay(DELAY);

            if (IsStepThreeValid())
            {
                var item = (Item as FilamentTypeValidator);
                (Item as FilamentTypeValidator).NozzleTemperatureRange = $"{item.NozzleMin.Value}-{item.NozzleMax.Value}";
                (Item as FilamentTypeValidator).BedTemperatureRange = $"{item.BedMin.Value}-{item.BedMax.Value}";
                (Item as FilamentTypeValidator).CoolingRange =  $"{item.CoolingMin.Value}-{item.CoolingMax.Value}";

                Step+=1;
                StepDescription="todo 4";

            }
            NextIsRunning = false;
        }

        if (Step == 2) 
        {
            DefaultNextStepAction("TDOD 3", IsStepTwoValid());
        }

        if (Step == 1)
        {
            DefaultNextStepAction("TDOD 2", IsStepOneValid());
        }

        IsRunning = false;
    }

    #endregion
}
