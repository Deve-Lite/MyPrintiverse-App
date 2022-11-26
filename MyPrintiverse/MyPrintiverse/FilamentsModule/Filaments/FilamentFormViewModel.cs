using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.FilamentsModule.Types;
using MyPrintiverse.Tools;
using System.Collections.ObjectModel;

namespace MyPrintiverse.FilamentsModule.Filaments;

public partial class FilamentFormViewModel : BaseFormViewModel<Filament>
{
    #region Properties

    [ObservableProperty]
    public FilamentType _selectedFilamentType;
    [ObservableProperty]
    private bool _isSelectedItemValid;

    #endregion

    #region Services

    protected IItemService<FilamentType> TypeService;

    protected IToast Toast;

    #endregion

    #region Collections

    public ObservableCollection<FilamentType> FilamentTypes { get; set; }

    #endregion 

    public FilamentFormViewModel(IMessageService messageService, IItemService<Filament> itemService, IItemService<FilamentType> typeService, IToast toast) : base(messageService, itemService)
    {
        TypeService = typeService;
        Toast = toast;
        Item = new FilamentValidator();

        FilamentTypes = new ObservableCollection<FilamentType>();

        SelectedFilamentType = new FilamentType();
        SelectedFilamentType.Description = "Please click any type to select it as type of filament.";
        SelectedFilamentType.Density = 0;
        SelectedFilamentType.ShortName = "Type not set.";
        SelectedFilamentType.EditedAtTicks = DateTime.Now.Ticks;

        TotalSteps = 4; 
        StepDescriptionList = new ObservableCollection<string>
        {
            "Select filament material.",
            "Fill base filament informations.",
            "Fill additional data.",
            "Check provided data."
        };

        StepDescription = StepDescriptionList[0];
        IsSelectedItemValid = true;
    }

    #region Overrides
    public override void OnAppearing()
    {
        base.OnAppearing();

        // TODO : Load from Settings
        (Item as FilamentValidator).Diameter.Value = "1.75";    
    }

    [RelayCommand]
    public override async Task StepBack()
    {
        if (Step == 2)
            DefaultPreviousStepAction();

        if (Step == 3)
            DefaultPreviousStepAction();

        if (Step == 4)
            DefaultPreviousStepAction();
    }

    public override bool IsStepOneValid() => !string.IsNullOrEmpty((Item as FilamentValidator)!.TypeId.Value);

    #endregion

    #region Protected

    [RelayCommand]
    public async Task Refresh()
    {
        IsBusy = true;
        IsRefreshing = true;

        FilamentTypes.Clear();

        foreach(var item in await TypeService.GetItemsAsync())
            FilamentTypes.Add(item);

        IsRefreshing = false;
        IsBusy = false;
    }



    [RelayCommand]
    public void TypeClicked(FilamentType filamentType)
    {
        if (filamentType.Id == (Item as FilamentValidator)!.TypeId.Value)
            return;

        //TODO : Data animation ???
        (Item as FilamentValidator)!.TypeId.Value = filamentType.Id;

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
        if (Step == 4)
        {
            NextIsRunning = true;
            await Task.Delay(DELAY);
            await manageItem.Invoke();
            NextIsRunning = false;
        }    
        

        if (Step == 3)
            DefaultNextStepAction(IsStepThreeValid());

        if (Step == 2)
            DefaultNextStepAction(IsStepTwoValid());

        if (Step == 1)
        {
            NextIsRunning = true;
            await Task.Delay(DELAY);
            if (IsStepOneValid())
            {
                IsSelectedItemValid = true;
                StepDescription = StepDescriptionList[Step];
                Step += 1;
            }
            else
            {
                IsSelectedItemValid = false;
            }

            NextIsRunning = false;
        }
        
    }


    #endregion
}
