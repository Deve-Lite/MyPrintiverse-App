using MyPrintiverse.FilamentsModule.Types;

namespace MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;


public class AddFilamentViewModel : FilamentsManageViewModel
{
    FilamentMock _filamentMock;
    public AddFilamentViewModel(IMessageService messageService, IItemService<Filament> itemService, IItemService<FilamentType> typeService, FilamentMock filamentMock) : base(messageService, itemService, typeService)
    {
        _filamentMock = filamentMock;
    }

    protected override async Task LoadData()
    {
        base.LoadData();
        (Item as FilamentValidator).ColorHex = "FFFFFF";
        (Item as FilamentValidator).Diameter.Value = 1.75;
    }
    public override void OnAppearing()
    {
        base.OnAppearing();

        Task.Run(async () =>
        {
            await Task.Delay(DELAY);
            await ItemService.AddItemAsync(await _filamentMock.GenerateFilament());
        });
    }
}

