using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.FilamentsModule.Types;
using MyPrintiverse.Tools;
using System.Collections.ObjectModel;

namespace MyPrintiverse.FilamentsModule.Filaments;

public partial class ManageFilamentViewModel : BaseItemManageViewModel<Filament>
{
    #region Properties

    [ObservableProperty]
    protected bool _stepTwo;

    [ObservableProperty]
    protected bool _stepThree;

    [ObservableProperty]
    public FilamentType _selectedFilamentType;

    #endregion

    #region Services

    private IItemService<FilamentType> TypeService;

    protected IToast Toast;

    #endregion

    #region Collections

    public ObservableCollection<FilamentType> FilamentTypes { get; set; }

    #endregion 

    public ManageFilamentViewModel(IMessageService messageService, IItemService<Filament> itemService, IItemService<FilamentType> typeService, IToast toast) : base(messageService, itemService)
    {
        TypeService = typeService;
        Toast = toast;
        Item = new FilamentValidator();

        //TO Thinkof
        SelectedFilamentType = new FilamentType();
    }

    #region Overrides
    public override void OnAppearing()
    {
        base.OnAppearing();
        Task.Run(async () => { FilamentTypes = (ObservableCollection<FilamentType>) await TypeService.GetItemsAsync(); });

        // TODO : Load from Settings
        (Item as FilamentValidator).Diameter.Value = "1.75";
    }

    [RelayCommand]
    public override async Task StepBack()
    {
        //TODO: Simulate Data Animation
        await Task.Delay(500);

        if (StepTwo)
        {
            StepOne = true;
            StepTwo = false;
            NextButtonTitle = "NEXT";
        }

        if (StepThree)
        {
            StepTwo = true;
            StepThree = false;
            NextButtonTitle = "NEXT";
        }

        if (FinishingStep)
        {
            StepThree = true;
            FinishingStep = false;
            NextButtonTitle = "NEXT";
        }

    }

    public override bool IsStepOneValid() => !string.IsNullOrEmpty((Item as FilamentValidator).TypeId);

    #endregion

    #region Protected

    [RelayCommand]
    protected void TypeClicked(FilamentType filamentType)
    {
        (Item as FilamentValidator).TypeId = filamentType.Id;

        SelectedFilamentType = FilamentTypes.FirstOrDefault(x => x.Id == filamentType.Id);
    } 


    protected virtual bool IsStepTwoValid() => (Item as FilamentValidator).Brand.Validate() &&
                                               (Item as FilamentValidator).Diameter.Validate() &&
                                               (Item as FilamentValidator).Color.Validate();
    protected virtual bool IsStepThreeValid() => (Item as FilamentValidator).NozzleTemperature.Validate() &&
                                                 (Item as FilamentValidator).BedTemperature.Validate() &&
                                                 (Item as FilamentValidator).CoolingRate.Validate()&&
                                                 (Item as FilamentValidator).Description.Validate();

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
                NextButtonTitle = "FINISH";
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
                NextButtonTitle = "NEXT";
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
                NextButtonTitle = "NEXT";
            }
            else
                await Toast.Toast("Some data is invalid.");
        }

        IsRunning = false;
    }


    #endregion
}
