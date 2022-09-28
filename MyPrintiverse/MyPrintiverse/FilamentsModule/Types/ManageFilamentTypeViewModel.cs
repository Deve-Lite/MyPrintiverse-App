
using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.FilamentsModule.Spools;
using MyPrintiverse.Tools;
using System.Globalization;

namespace MyPrintiverse.FilamentsModule.Types;

public abstract partial class ManageFilamentTypeViewModel : BaseItemManageViewModel<FilamentType>
{
    #region Properties

    [ObservableProperty]
    protected bool _stepTwo;

    [ObservableProperty]
    protected bool _stepThree;


    protected IToast Toast;

    #endregion 

    protected ManageFilamentTypeViewModel(IMessageService messageService, IItemService<FilamentType> itemService, IToast toast) : base(messageService, itemService)
    {
        Item = new FilamentTypeValidator();
        Toast = toast;
    }

    #region Overrides

    [RelayCommand]
    public override async Task StepBack()
    {
        //TODO: Simulate Data Animation
        await Task.Delay(500);

        if (FinishingStep)
        {
            StepThree = true;
            FinishingStep = false;
            NextButtonTitle = "NEXT";
        }

        if (StepThree)
        {
            StepTwo = true;
            StepThree = false;
            NextButtonTitle = "NEXT";
        }

        if (StepTwo)
        {
            StepOne = true;
            StepTwo = false;
            NextButtonTitle = "NEXT";
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
        item!.NozzleMin.Validate();

        if (!string.IsNullOrEmpty(item.NozzleMax.Value))
            item.NozzleMax.Validate();
    }

    [RelayCommand]
    protected void CoolingValidate()
    {
        var item = (Item as FilamentTypeValidator);
        item!.CoolingMin.Validate();

        if (!string.IsNullOrEmpty(item.CoolingMax.Value))
            item.CoolingMax.Validate();
    }

    [RelayCommand]
    protected void BedValidate()
    {
        var item = (Item as FilamentTypeValidator);
        item!.BedMin.Validate();

        if (!string.IsNullOrEmpty(item.BedMax.Value))
            item.BedMax.Validate();
    }

    protected virtual bool IsStepTwoValid() => (Item as FilamentTypeValidator).Density.Validate() &&
                                               (Item as FilamentTypeValidator).MaxServiceTempearature.Validate() &&
                                               (Item as FilamentTypeValidator).NozzleMin.Validate() &&
                                               (Item as FilamentTypeValidator).NozzleMax.Validate() &&
                                               (Item as FilamentTypeValidator).BedMin.Validate() &&
                                               (Item as FilamentTypeValidator).BedMax.Validate() &&
                                               (Item as FilamentTypeValidator).CoolingMin.Validate() &&
                                               (Item as FilamentTypeValidator).CoolingMin.Validate();
    protected virtual bool IsStepThreeValid() => true;

    protected async Task Next(Func<Task> manageItem)
    {
        IsRunning = true;

        //TODO: Simulate Data Animation
        await Task.Delay(500);

        if (FinishingStep)
        {
            await manageItem.Invoke();
        }

        if (StepThree)
        {
            if (IsStepThreeValid())
            {
                StepThree = false;
                FinishingStep = true;
                NextButtonTitle = "Finish";
            }
            else
                await Toast.Toast("Some data is invalid.");
        }

        if (StepTwo) 
        {
            if (IsStepTwoValid())
            {
                StepTwo = false;
                StepThree = true;
                NextButtonTitle = "Next";
            }
            else
                await Toast.Toast("Some data is invalid.");
        }

        if (StepOne)
        {
            if (IsStepOneValid())
            {
                StepOne = false;
                StepTwo = true;
                NextButtonTitle = "Next";
            }
            else
                await Toast.Toast("Some data is invalid.");
        }

        IsRunning = false;
    }

    #endregion
}
