using MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentPage;
using MyPrintiverse.Tools.Mock;
using MyPrintiverse.Tools.Settings;
using System.Collections.ObjectModel;

namespace MyPrintiverse.FilamentsModule.Filaments.FilamentsPage
{
    public class FilamentsViewModel : GroupedCollectionViewModel<Filament, AddFilamentView, EditFilamentView, FilamentView>
    {

        public FilamentsViewModel(MessageService messagingService, FilamentService itemsService) : base(messagingService, itemsService)
        { 
        }

        public override void OnAppearing()
        {
            IsEnabled = true;
            base.OnAppearing();
        }

        protected override string GetNewGroupName(Filament item)
        {
            return item.Brand.Trim();
        }

        protected override int GetIndex(Filament item)
        {
            return Items.IndexOf(Items.FirstOrDefault(x => x.Name == item.Brand));
        }
    }
}
