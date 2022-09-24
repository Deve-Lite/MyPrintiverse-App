using MyPrintiverse.FilamentsModule.Types;

namespace MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;


public class AddFilamentViewModel : FilamentsManageViewModel
{
    FilamentMock FilamentMock;
    public AddFilamentViewModel(IMessageService messageService, IItemService<Filament> itemService, IItemService<FilamentType> typeService, FilamentMock filamentMock) : base(messageService, itemService, typeService)
    {
        FilamentMock = filamentMock;
    }


    public override void OnAppearing()
    {
        base.OnAppearing();

        Task.Run(async () => { await ItemService.AddItemAsync(await FilamentMock.GenerateFilament()); });

    }

}

