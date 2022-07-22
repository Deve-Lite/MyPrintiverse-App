using MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentPage;
using MyPrintiverse.Tools.Mock;
using System.Collections.ObjectModel;

namespace MyPrintiverse.FilamentsModule.Filaments.FilamentsPage
{
    public class FilamentsViewModel : GroupedCollectionViewModel<Filament, AddFilamentView, EditFilamentView, FilamentView>
    {

        public bool IsEnabled = true;

        public FilamentsViewModel(MessageService messagingService, FilamentService itemsService) : base(messagingService, itemsService)
        { 
            Items = new ObservableCollection<GroupedItem<Filament>>();
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override async Task AddItem()
        {
            await ItemsService.AddItemAsync(FilamentMock.GenerateFilament());
            await UpdateItemsOnAppearing();
        }

        protected override string GetNewGroupName(Filament item)
        {
            return item.Brand;
        }

        protected override int GetIndex(Filament item)
        {
            return Items.IndexOf(Items.FirstOrDefault(x => x.Name == item.Brand));
        }
    }
}
