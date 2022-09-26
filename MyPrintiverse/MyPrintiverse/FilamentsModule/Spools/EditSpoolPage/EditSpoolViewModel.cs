
using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.FilamentsModule.Filaments;
using MyPrintiverse.Tools;
using System.Globalization;

namespace MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class EditSpoolViewModel : ManageSpoolViewModel
{
    #region Fields

    public string Id { get; set; }

    #endregion

    public EditSpoolViewModel(IMessageService messageService, IItemService<Spool> itemService, IItemService<Filament> filamentService, IToast toast) : base(messageService, itemService, filamentService, toast)
    {
    }

    #region Overrides
    public override void OnAppearing()
    {
        base.OnAppearing();

        Task.Run(async () => { Item = new SpoolValidator(await ItemService.GetItemAsync(Id)); });
    }

    [RelayCommand]
    public override async Task NextStep() => await Next(EditItem);

    public async Task EditItem() => await ManageItem(async (spool) => { return await ItemService.UpdateItemAsync(spool); });

    #endregion

}