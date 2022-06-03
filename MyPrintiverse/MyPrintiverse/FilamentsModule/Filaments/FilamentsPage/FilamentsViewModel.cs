using MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentPage;

namespace MyPrintiverse.FilamentsModule.Filaments.ViewModels
{
    public class FilamentsViewModel : GroupedCollectionViewModel<Filament, AddFilamentView, EditFilamentView, FilamentView>
    {
        public FilamentsViewModel(FilamentService filamentService)
        {
            ItemsService = filamentService;
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
