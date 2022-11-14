
using System.Threading.Tasks;
using MyPrintiverse.FilamentsModule.Types;
using MyPrintiverse.Tools;

namespace MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;


public partial class AddFilamentViewModel : FilamentFormViewModel
{
    public AddFilamentViewModel(IMessageService messageService, IItemService<Filament> itemService, IItemService<FilamentType> typeService, IToast toast) : base(messageService, itemService, typeService, toast)
    {
    }

    #region Overrides

    public override void OnAppearing()
    {
        base.OnAppearing();

        Task.Run(async () =>
        {
            foreach (var item in await TypeService.GetItemsAsync())
                FilamentTypes.Add(item);
        });
    }


    [RelayCommand]
    public override async Task NextStep() => await Next(AddItem);

    public async Task AddItem() => await ManageItem(async (spool) => { return await ItemService.AddItemAsync(spool); });

    #endregion
}

