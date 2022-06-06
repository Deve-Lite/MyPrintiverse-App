using System;
namespace MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage
{
	public class AddFilamentViewModel : AddItemViewModel<Filament>
	{
		public AddFilamentViewModel(FilamentService filamentService)
		{
			ItemService = filamentService;
		}
	}
}

