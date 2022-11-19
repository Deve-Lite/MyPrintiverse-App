using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.FilamentsModule.Filaments;
using MyPrintiverse.FilamentsModule.Spools;
using MyPrintiverse.Tools;
using System.Collections.ObjectModel;
using System.Globalization;

namespace MyPrintiverse.FilamentsModule;

[QueryProperty(nameof(FilamentId), nameof(FilamentId))]
public partial class SpoolFormViewModel : BaseFormViewModel<Spool>
{
    #region Fields
    public string FilamentId { get; set; }

    [ObservableProperty]
    public string _currency;

    [ObservableProperty]
    public Filament _filament;

    protected IItemService<Filament> FilamentService;

    protected IToast Toast;

    #endregion

    public SpoolFormViewModel(IMessageService messageService, IItemService<Spool> itemService, IItemService<Filament> filamentService, IToast toast) : base(messageService, itemService)
    {
        FilamentService = filamentService;
        Toast = toast;
        Filament = new Filament();
        Item = new SpoolValidator();

        StepDescriptionList = new ObservableCollection<string>
        {
            "Fill base spool informations.",
            "Check provided data."
        };

        StepDescription = StepDescriptionList[0];
    }

    #region Protected

    protected async Task Next(Func<Task> manageItem)
    {
        IsRunning = true;

        if (Step == 2)
        {
            NextIsRunning = true;

            await Task.Delay(DELAY);

            /* Parse will not throw Exception because of NumberRules */
            var avaliableWeight = double.Parse((Item as SpoolValidator).AvaliableWeight.Value.Replace(',', '.'), CultureInfo.InvariantCulture);

            if (avaliableWeight == 0)
                (Item as SpoolValidator).IsFinished = true;
            else
                (Item as SpoolValidator).IsFinished = false;

            await manageItem.Invoke();
            NextIsRunning = false;
        }

        if (Step == 1)
        {
            NextIsRunning = true;

            await Task.Delay(DELAY);

            if (IsStepOneValid())
            {
                Step = 2;
                StepDescription = StepDescriptionList[Step-1];

                
                Filament = await FilamentService.GetItemAsync(FilamentId);
            }

            NextIsRunning = false;
        }

        IsRunning = false;
    }

    [RelayCommand]
    protected void StandardWeightValidate()
    {
        var item = (Item as SpoolValidator);
        item!.StandardWeight.Validate();

        if (!string.IsNullOrEmpty(item.AvaliableWeight.Value))
            item.AvaliableWeight.Validate();
    }

    #endregion

    #region Overrides
    public override void OnAppearing()
    {
        base.OnAppearing();
        //TODO: odczytanie z ustawień
        Currency = "PLN";
    }

    [RelayCommand]
    public override async Task StepBack()
    {
        if (Step == 2)
            DefaultPreviousStepAction(); 
    }

    #endregion

}
