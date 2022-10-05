using MyPrintiverse.FilamentsModule.Types;
using MyPrintiverse.Tools;

namespace MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;

[QueryProperty(nameof(Id),nameof(Id))]
public partial class EditFilamentViewModel : ManageFilamentViewModel
{
    public string Id { get; set; }
    public EditFilamentViewModel(IMessageService messageService, IItemService<Filament> itemService, IItemService<FilamentType> typeService, IToast toast) : base(messageService, itemService, typeService, toast)
    {
    }

    #region Overrides
    public override void OnAppearing()
    {
        base.OnAppearing();

        Task.Run(async () => { Item = new FilamentValidator(await ItemService.GetItemAsync(Id)); });

        // Think of what if type not found
        SelectedFilamentType = FilamentTypes!.FirstOrDefault(x => x.Id == (Item as FilamentValidator)!.TypeId.Value);
    }

    [RelayCommand]
    public override async Task NextStep() => await Next(EditItem);

    public async Task EditItem() => await ManageItem(async (spool) => { return await ItemService.UpdateItemAsync(spool); });

    #endregion
}