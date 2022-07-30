namespace MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;

public class AddFilamentViewModel : BaseAddItemViewModel<Filament>
{



	public AddFilamentViewModel(MessageService messageService, FilamentService itemService) : base(messageService, itemService)
	{
            Item = new FilamentValidator();
    }
}

