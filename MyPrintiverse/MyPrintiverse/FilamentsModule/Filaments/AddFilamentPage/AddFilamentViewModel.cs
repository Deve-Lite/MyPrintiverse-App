using MyPrintiverse.FilamentsModule.Types;
using MyPrintiverse.Tools.Mock;

namespace MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;

public class AddFilamentViewModel : FilamentsManageViewModel
{
    public AddFilamentViewModel(MessageService messageService, FilamentService itemService, FilamentTypeService typeService) : base(messageService, itemService, typeService)
    {

    }

    protected override async Task LoadData()
    {
        base.LoadData();
        (Item as FilamentValidator).ColorHex = "FFFFFF";
        (Item as FilamentValidator).Diameter.Value = 1.75;
    }

    public async Task AddItem()
    {
        IsRunning = true;

        await Task.Delay(DELAY);

        if (await ItemService.AddItemAsync(/*MOCK*/))
            await Shell.Current.GoToAsync("..", true);

        IsRunning = false;
    }
}

