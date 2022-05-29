

namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// Base ViewModel for view displaying collection with key service.
    /// </summary>
    /// <typeparam name="T">Collection Model.</typeparam>
    /// <typeparam name="TAdd"> Class (View) adding model.</typeparam>
    /// <typeparam name="TEdit"> Class (View) editing model.</typeparam>
    /// <typeparam name="TDisplay"> Class (View) displaying model.</typeparam>
    [QueryProperty(nameof(Id), nameof(Id))]
    public class KeyCollectionViewModel<T, TAdd, TEdit, TDisplay> : BaseViewModel where T : BaseModel
    {
        public ObservableCollection<T> Items { get; set; }

        public AsyncCommand RefreshItemsCommand { get; set; }
        public AsyncCommand AddItemCommand { get; set; }

        public AsyncCommand<T> EditItemCommand { get; set; }
        public AsyncCommand<T> OpenItemCommand { get; set; }
        public AsyncCommand<T> DeleteItemCommand { get; set; }

        string PrevId;
        public string Id { get; set; }

        protected IItemAsyncService<T> ItemService;
        protected IKeyItemAsyncService<T> KeyItemsService;

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            RefreshItemsCommand = new AsyncCommand(RefreshItems, CanExecute);
            AddItemCommand = new AsyncCommand(AddItem, CanExecute);
            EditItemCommand = new AsyncCommand<T>(EditItem, CanExecute);
            OpenItemCommand = new AsyncCommand<T>(OpenItem, CanExecute);
            DeleteItemCommand = new AsyncCommand<T>(DeleteItem, CanExecute);

            await UpdateItemsOnAppearing();
        }

        protected virtual async Task AddItem() => await Shell.Current.GoToAsync($"{nameof(TAdd)}");

        protected virtual async Task UpdateItemsOnAppearing()
        {
            if (Id != PrevId)
                await RefreshItems();

            IsBusy = true;
            IsRefreshing = true;

            List<T> data = (List<T>)await KeyItemsService.GetItemsByKeyAsync(Id);

            int i = 0;
            foreach (T item in new List<T>(Items))
            {
                T newItem = data.First(x => x.Id == item.Id);

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

            foreach (T item in data)
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

        protected virtual async Task EditItem(T item) => await Shell.Current.GoToAsync($"{nameof(TEdit)}?Id={item.Id}");

        protected virtual async Task DeleteItem(T item)
        {

            if (await ItemService.DeleteItemAsync(item.Id))
                Items.Remove(item);

            IsBusy = false;
        }

        protected virtual async Task OpenItem(T item) => await Shell.Current.GoToAsync($"{nameof(TDisplay)}?Id={item.Id}");
    }
}
