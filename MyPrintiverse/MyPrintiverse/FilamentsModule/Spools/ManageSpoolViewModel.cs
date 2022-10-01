using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.FilamentsModule.Filaments;
using MyPrintiverse.FilamentsModule.Spools;
using MyPrintiverse.Tools;
using System.Globalization;

namespace MyPrintiverse.FilamentsModule;

[QueryProperty(nameof(FilamentId), nameof(FilamentId))]
public partial class ManageSpoolViewModel : BaseItemManageViewModel<Spool>
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

    public ManageSpoolViewModel(IMessageService messageService, IItemService<Spool> itemService, IItemService<Filament> filamentService, IToast toast) : base(messageService, itemService)
    {
        FilamentService = filamentService;
        Toast = toast;

        Filament = new Filament();
        Item = new SpoolValidator();
    }

    #region Protected

    protected async Task Next(Func<Task> manageItem)
    {
        IsRunning = true;

        //TODO: Simulate Data Animation
        await Task.Delay(500);

        if (FinishingStep)
        {
            /* Parse will not throw Exception because of NumberRules */
            var avaliableWeight = double.Parse((Item as SpoolValidator).AvaliableWeight.Value.Replace(',', '.'), CultureInfo.InvariantCulture);

            if (avaliableWeight == 0)
                (Item as SpoolValidator).IsFinished = true;
            else
                (Item as SpoolValidator).IsFinished = false;

            await manageItem.Invoke();
        }

        if (StepOne)
        {
            if (IsStepOneValid())
            {
                StepOne = false;
                FinishingStep = true;
                NextButtonTitle = "Finish";

                if(string.IsNullOrEmpty(Filament.Id))
                    Filament = await FilamentService.GetItemAsync(FilamentId);

            }
            else
                await Toast.Toast("Some data is invalid.");
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
        //TODO: Simulate Data Animation
        await Task.Delay(500);

        if (FinishingStep)
        {
            StepOne = true;
            FinishingStep = false;
            NextButtonTitle = "NEXT";
        }
    }

    #endregion

}
