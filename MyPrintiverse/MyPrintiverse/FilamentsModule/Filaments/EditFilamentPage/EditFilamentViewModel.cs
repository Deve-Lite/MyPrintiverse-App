using System;
namespace MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage
{
	public class EditFilamentViewModel : BaseEditItemViewModel<Filament>
	{
		public EditFilamentViewModel(MessageService messageService, FilamentService itemService) : base(messageService, itemService)
		{
			Item = new FilamentValidator();
			// Do sprawdzenia czy działa bindowanie 
			(Item as FilamentValidator).Id = "tsetset";
        }
	}
}

