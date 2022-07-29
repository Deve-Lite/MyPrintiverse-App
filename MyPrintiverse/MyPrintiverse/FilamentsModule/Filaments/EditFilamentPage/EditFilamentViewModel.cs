using System;
namespace MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage
{
	public class EditFilamentViewModel : BaseEditItemViewModel<Filament>
	{
		public EditFilamentViewModel(MessageService messageService, FilamentService itemService) : base(messageService, itemService)
		{
			Item = new FilamentValidator(ValidationMode.Full);
			// Do sprawdzenia czy działa bindowanie 
			(Item as FilamentValidator).Id = "tsetset";
        }
	}
}

