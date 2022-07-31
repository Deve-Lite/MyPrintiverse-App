using MyPrintiverse.FilamentsModule.Types;

namespace MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;

public class AddFilamentViewModel : BaseAddItemViewModel<Filament>
{
    private FilamentTypeService TypeService;

    

    public AddFilamentViewModel(MessageService messageService, FilamentService itemService, FilamentTypeService typeService) : base(messageService, itemService)
    {
        var typeServiceExceptionMessage = GetExceptionMessage<BaseAddItemViewModel<Filament>>(nameof(typeService));
        TypeService = typeService ?? throw new ArgumentNullException(typeServiceExceptionMessage);
    }

    public override void OnAppearing()
    {
        base.OnAppearing();
        Item = new FilamentValidator();
        IsEnabled = true;
    }
}

