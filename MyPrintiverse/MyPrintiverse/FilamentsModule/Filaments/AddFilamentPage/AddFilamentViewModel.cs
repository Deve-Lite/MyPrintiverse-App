using MyPrintiverse.FilamentsModule.Types;

namespace MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;


public class AddFilamentViewModel : FilamentsManageViewModel
{
    public AddFilamentViewModel(IMessageService messageService, IItemService<Filament> itemService, IItemService<FilamentType> typeService) : base(messageService, itemService, typeService)
    {
        
    }
}

