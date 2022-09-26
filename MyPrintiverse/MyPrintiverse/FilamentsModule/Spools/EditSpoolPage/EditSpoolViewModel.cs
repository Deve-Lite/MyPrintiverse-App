
using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.FilamentsModule.Filaments;
using MyPrintiverse.Tools;
using System.Globalization;

namespace MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;

[QueryProperty(nameof(FilamentId), nameof(FilamentId))]
public partial class EditSpoolViewModel : BaseEditItemViewModel<Spool>
{
    #region Fields
    public string FilamentId { get; set; }

    [ObservableProperty]
    public string _currency;

    [ObservableProperty]
    public Filament _filament;

    IItemService<Filament> FilamentService;

    IToast Toast;

    #endregion

    public EditSpoolViewModel(IMessageService messageService, IItemService<Spool> itemService, IItemService<Filament> filamentService, IToast toast) : base(messageService, itemService)
	{
        FilamentService = filamentService;
        Filament = new Filament();
        Item = new SpoolValidator();
        Toast = toast;
    }

    #region Overrides
    public override void OnAppearing()
    {
        base.OnAppearing();

        Task.Run(async () => 
        { 
            Filament = await FilamentService.GetItemAsync(FilamentId);
            Item = new SpoolValidator(await ItemService.GetItemAsync(Id));
        });

        //TODO: odczytanie z ustawień
        Currency = "PLN";
    }

    [RelayCommand]
    public override async Task NextStep()
    {
        IsRunning = true;

        //TODO: Simulate Data Animation
        await Task.Delay(500);

        if (FinishingStep)
        {
            // Parse will not throw Exception because of NumberRules
            var avaliableWeight = double.Parse((Item as SpoolValidator).AvaliableWeight.Value.Replace(',', '.'), CultureInfo.InvariantCulture);

            if (avaliableWeight == 0)
                (Item as SpoolValidator).IsFinished = true;
            else
                (Item as SpoolValidator).IsFinished = false;
            await EditItem();
        }

        if (StepOne)
        {
            if (IsStepOneValid())
            {
                StepOne = false;
                FinishingStep = true;
                NextButtonTitle = "EDIT";
            }
            else
                await Toast.Toast("Some data is invalid.");
        }

        IsRunning = false;
    }

    [RelayCommand]
    public override async Task StepBack()
    {
        if (FinishingStep)
        {
            StepOne = true;
            FinishingStep = false;
            NextButtonTitle = "NEXT";
        }
    }
    #endregion
}