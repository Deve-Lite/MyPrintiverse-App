using MyPrintiverse.FilamentsModule.Filaments;
using MyPrintiverse.Tools;

namespace MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;


public partial class AddSpoolViewModel : SpoolFormViewModel
{

    public AddSpoolViewModel(IMessageService messageService, IItemService<Spool> itemService, IItemService<Filament> filamentService, IToast toast) : base(messageService, itemService, filamentService, toast)
	{
    }

    #region Overrides
    public override void OnAppearing()
    {
        base.OnAppearing();

        (Item as SpoolValidator)!.FilamentId = FilamentId;
    }

    [RelayCommand]
    public override async Task NextStep() => await Next(AddItem);

    public async Task AddItem() => await ManageItem(ItemService.AddItemAsync);

    #endregion
}