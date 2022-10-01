using MyPrintiverse.FilamentsModule.Spools;
using MyPrintiverse.FilamentsModule.Types;
using MyPrintiverse.Tools;

namespace MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;


public partial class AddFilamentViewModel : ManageFilamentViewModel
{
    FilamentMock fm;
    public AddFilamentViewModel(FilamentMock filamentMock,IMessageService messageService, IItemService<Filament> itemService, IItemService<FilamentType> typeService, IToast toast) : base(messageService, itemService, typeService, toast)
    {
        fm = filamentMock;
    }


    public override void OnAppearing()
    {
        base.OnAppearing();
        Task.Run(async () => { await ItemService.AddItemAsync(await fm.GenerateFilament()); });
    }

    #region Overrides
    [RelayCommand]
    public override async Task NextStep() => await Next(AddItem);

    public async Task AddItem() => await ManageItem(async (spool) => { return await ItemService.AddItemAsync(spool); });

    #endregion
}

