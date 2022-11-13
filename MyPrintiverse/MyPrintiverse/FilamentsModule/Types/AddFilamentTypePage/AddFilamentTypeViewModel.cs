using MyPrintiverse.FilamentsModule.Spools;
using MyPrintiverse.Tools;

namespace MyPrintiverse.FilamentsModule.Types.AddFilamentTypePage;

public partial class AddFilamentTypeViewModel : TypeFormViewModel
{
    public AddFilamentTypeViewModel(IMessageService messageService, IItemService<FilamentType> itemService, IToast toast) : base(messageService, itemService, toast)
    {
    }

    #region Overrides

    [RelayCommand]
    public override async Task NextStep() => await Next(AddItem);

    public async Task AddItem() => await ManageItem(ItemService.AddItemAsync);

    #endregion
}