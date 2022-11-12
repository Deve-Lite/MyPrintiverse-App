using MyPrintiverse.Tools;

namespace MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class EditFilamentTypeViewModel : TypeFormViewModel
{

    public string Id { get; set; }

    public EditFilamentTypeViewModel(IMessageService messageService, IItemService<FilamentType> itemService, IToast toast) : base(messageService, itemService, toast)
    {
    }


    #region Overrides
    public override void OnAppearing()
    {
        base.OnAppearing();

        Task.Run(async () => { Item = new FilamentTypeValidator(await ItemService.GetItemAsync(Id)); });
    }

    [RelayCommand]
    public override async Task NextStep() => await Next(EditItem);

    public async Task EditItem() => await ManageItem(async (spool) => { return await ItemService.UpdateItemAsync(spool); });

    #endregion

}