﻿using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Spools;

namespace MyPrintiverse.FilamentsModule.Filaments.FilamentPage
{
	public class FilamentViewModel : BaseItemViewModel<Filament, EditFilamentView>
	{
		public AsyncCommand<Spool> DisplaySpoolCommand;

		public FilamentViewModel(MessageService messageService, FilamentService itemService) : base(messageService, itemService)
		{
            DisplaySpoolCommand = new AsyncCommand<Spool>(DisplaySpool, CanExecute);
        }

		private async Task DisplaySpool(Spool item)
        {
			await Shell.Current.GoToAsync("");
        }
	}
}

