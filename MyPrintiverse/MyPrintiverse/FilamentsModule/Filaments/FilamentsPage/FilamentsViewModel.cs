using MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentPage;

namespace MyPrintiverse.FilamentsModule.Filaments.FilamentsPage
{
    public class FilamentsViewModel : GroupedCollectionViewModel<Filament, AddFilamentView, EditFilamentView, FilamentView>
    {
        public FilamentsViewModel(MessageService messagingService, FilamentService itemsService) : base(messagingService, itemsService)
        {
            // przeniesienie inicjalizacji na base view
            Items = new ObservableCollection<GroupedItem<Filament>>();
        }

        protected internal override void OnAppearing()
        {
            base.OnAppearing();

            var f = new Filament { Brand = "Brand", ColorName="Color", Diameter=1.75, TypeName="Name", ShortDescription="Description", ColorHex="#fdb913" };
            var l = new ObservableCollection<Filament>();
            l.Add(f);
            l.Add(f);
            l.Add(f);
            l.Add(f);
            GroupedItem<Filament> x = new GroupedItem<Filament>("Devil", l);
            Items.Add(x);

            var f1 = new Filament { Brand = "Brand", ColorName="Color", Diameter=1.75, TypeName="Name", ShortDescription="Description", ColorHex="#fdb913" };
            var l1 = new ObservableCollection<Filament>();
            l.Add(f1);
            l.Add(f1);
            var x1 = new GroupedItem<Filament>("Devil22", l1);
            Items.Add(x1);

            IsBusy = false;

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
