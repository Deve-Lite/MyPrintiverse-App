using System;
namespace MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage
{
	public class EditFilamentViewModel : EditItemViewModel<Filament>
	{
		public EditFilamentViewModel(FilamentService filamentService)
		{
			ItemService = (IItemAsyncService<Filament>)filamentService;
		}
	}
}

