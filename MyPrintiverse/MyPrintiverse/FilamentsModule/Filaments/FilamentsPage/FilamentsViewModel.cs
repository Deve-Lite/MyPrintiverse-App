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
        bool isEnabled;
        public bool IsEnabled { get=> isEnabled; set=> SetProperty(ref isEnabled, value); }

        public AsyncCommand SwapThemeCommand { get; }

        public async Task SwapTheme()
        {
            Theme theme = new Theme();

            if (App.Current.UserAppTheme == AppTheme.Dark)
                theme.SetTheme(AppTheme.Light);
            else
                theme.SetTheme(AppTheme.Dark);
        }

        public FilamentsViewModel(MessageService messagingService, FilamentService itemsService) : base(messagingService, itemsService)
        { 
            Items = new ObservableCollection<GroupedItem<Filament>>();
            SwapThemeCommand = new AsyncCommand(SwapTheme);
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            IsEnabled = true;
        }

        protected override async Task AddItem()
        {
            await ItemsService.AddItemAsync(FilamentMock.GenerateFilament());
            await UpdateItemsOnAppearing();
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
