using System;
using MyPrintiverse.FilamentsModule.Spools;

namespace MyPrintiverse.FilamentsModule.Filaments.FilamentPage
{
	public class FilamentViewModel : DisplayItemViewModel<Filament, EditFilamentView>
	{
		// TODO
		// Zaleznie co wymysla graficy 2 listy lub 3

		public AsyncCommand<Spool> DisplaySpoolCommand;

		public FilamentViewModel(FilamentService filamentService)
		{
			ItemService = filamentService;

			DisplaySpoolCommand = new AsyncCommand<Spool>(DisplaySpool, CanExecute);
		}

		private async Task DisplaySpool(Spool item)
        {
			await Shell.Current.GoToAsync("");
        }

	}
}

