

using MyPrintiverse.FilamentsModule.Spools;

namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// Base ViewModel for view displaying collection with key service.
    /// </summary>
    /// <typeparam name="TBaseModel"> Model inheriting from BaseModel. </typeparam>
    /// <typeparam name="TAdd"> Class (View) adding model.</typeparam>
    /// <typeparam name="TEdit"> Class (View) editing model.</typeparam>
    /// <typeparam name="TDisplay"> Class (View) displaying model.</typeparam>
    [QueryProperty(nameof(Id), nameof(Id))]
    public class KeyCollectionViewModel<TBaseModel, TAdd, TEdit, TDisplay> : BaseViewModel where TBaseModel : BaseModel
    {
        public ObservableCollection<TBaseModel> Items { get; set; }

        public AsyncCommand RefreshItemsCommand { get; set; }
        public AsyncCommand AddItemCommand { get; set; }

        public AsyncCommand<TBaseModel> EditItemCommand { get; set; }
        public AsyncCommand<TBaseModel> OpenItemCommand { get; set; }
        public AsyncCommand<TBaseModel> DeleteItemCommand { get; set; }

        private string PrevId;
        public string Id { get; set; }

        protected IItemAsyncService<TBaseModel> ItemService;
        protected IItemKeyAsyncService<TBaseModel> KeyItemsService;

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            RefreshItemsCommand = new AsyncCommand(RefreshItems, CanExecute);
            AddItemCommand = new AsyncCommand(AddItem, CanExecute);
            EditItemCommand = new AsyncCommand<TBaseModel>(EditItem, CanExecute);
            OpenItemCommand = new AsyncCommand<TBaseModel>(OpenItem, CanExecute);
            DeleteItemCommand = new AsyncCommand<TBaseModel>(DeleteItem, CanExecute);

            await UpdateItemsOnAppearing();
        }

        protected virtual async Task AddItem() => await Shell.Current.GoToAsync($"{typeof(TAdd).Name}");

        protected virtual async Task UpdateItemsOnAppearing()
        {
            if (Id != PrevId)
                await RefreshItems();

            IsBusy = true;
            IsRefreshing = true;

            List<TBaseModel> data = (List<TBaseModel>)await KeyItemsService.GetItemsByKeyAsync(Id);

            int i = 0;
            foreach (TBaseModel item in new List<TBaseModel>(Items))
            {
                TBaseModel newItem = data.First(x => x.Id == item.Id);

                if (newItem == null)
                {
                    Items.Remove(item);
                    data.Remove(item);
                }
                else if (item.EditedAt == newItem.EditedAt)
                {
                    Items[Items.IndexOf(item)] = newItem;
                    data.Remove(item);
                }
            }

            foreach (TBaseModel item in data)
                Items.Add(item);

            IsRefreshing = false;
            IsBusy = false;
        }

        protected virtual async Task RefreshItems()
        {

            IsRefreshing = true;

            Items.Clear();

            foreach (var item in await KeyItemsService.GetItemsByKeyAsync(Id))
                Items.Add(item);

            IsBusy = false;
            IsRefreshing = false;
        }

        protected virtual async Task EditItem(TBaseModel item) => await Shell.Current.GoToAsync($"{typeof(TEdit).Name}?Id={item.Id}");

        protected virtual async Task DeleteItem(TBaseModel item)
        {

            if (await ItemService.DeleteItemAsync(item.Id))
                Items.Remove(item);

            IsBusy = false;
        }

        protected virtual async Task OpenItem(TBaseModel item) => await Shell.Current.GoToAsync($"{typeof(TDisplay).Name}?Id={item.Id}");
    }
}
