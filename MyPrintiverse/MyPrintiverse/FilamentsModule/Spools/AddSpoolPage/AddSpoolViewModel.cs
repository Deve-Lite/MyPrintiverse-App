
using CommunityToolkit.Mvvm.ComponentModel;

namespace MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;

[QueryProperty(nameof(Id),nameof(Id))]
public partial class AddSpoolViewModel : BaseAddItemViewModel<Spool>
{
    #region Fields

    public string Id { get; set; }

    [ObservableProperty]
    public bool _stepOne;

    [ObservableProperty]
    public bool _finishingStep;

    [ObservableProperty]
    public string _currency;

    #endregion

    public AddSpoolViewModel(IMessageService messageService, IItemService<Spool> itemService) : base(messageService, itemService)
	{
    }

    public override async void OnAppearing()
    {
        base.OnAppearing();
        StepOne = true;
        FinishingStep = false;

        //Todo odczytanie z ustawień
        Currency = "PLN";

        Item = new SpoolValidator();
        (Item as SpoolValidator).FilamentId = Id;
        //(Item as SpoolValidator);
        //await ItemService.AddItemAsync(SpoolMock.GenerateSpool(Id));
    }

    [RelayCommand]
    public void IsStepOneValid()
    {
        var isValid = Item.Validate();
        if (isValid)
        {
            StepOne = false;
            FinishingStep = true;
        }
    }
}