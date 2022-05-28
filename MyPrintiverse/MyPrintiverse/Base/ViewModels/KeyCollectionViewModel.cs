

namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// Base ViewModel for view displaying collection with key service.
    /// </summary>
    /// <typeparam name="Model"></typeparam>
    /// <typeparam name="AddViewModel"></typeparam>
    /// <typeparam name="EditViewModel"></typeparam>
    /// <typeparam name="DisplayViewModel"></typeparam>
    [QueryProperty(nameof(Id), nameof(Id))]
    public class KeyCollectionViewModel<Model, AddViewModel, EditViewModel, DisplayViewModel> : BaseViewModel
    {
        public ObservableCollection<Model> Items { get; set; }

        public AsyncCommand RefreshItemsCommand { get; set; }
        public AsyncCommand AddItemCommand { get; set; }

        public AsyncCommand<Model> EditItemCommand { get; set; }
        public AsyncCommand<Model> OpenItemCommand { get; set; }
        public AsyncCommand<Model> DeleteItemCommand { get; set; }

        string PrevId;
        public string Id { get; set; }

        protected IItemAsyncService<Model> ItemService;
        protected IKeyItemAsyncService<Model> KeyItemsService;

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            RefreshItemsCommand = new AsyncCommand(RefreshItems);
            AddItemCommand = new AsyncCommand(AddItem);
            EditItemCommand = new AsyncCommand<Model>(EditItem);
            OpenItemCommand = new AsyncCommand<Model>(OpenItem);
            DeleteItemCommand = new AsyncCommand<Model>(DeleteItem);

            await UpdateItemsOnAppearing();
        }

        protected virtual async Task AddItem()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await Shell.Current.GoToAsync($"{nameof(AddViewModel)}");
        }

        protected virtual async Task UpdateItemsOnAppearing()
        {
            if (Id != PrevId)
                await RefreshItems();

            IsBusy = true;
            IsRefreshing = true;

            List<Model> data = (List<Model>)await KeyItemsService.GetItemsByKeyAsync(Id);

            int i = 0;
            foreach (Model item in new List<Model>(Items))
            {
                Model newItem = data.First(x => (x as BaseModel).Id == (item as BaseModel).Id);

                if (newItem == null)
                {
                    Items.Remove(item);
                    data.Remove(item);
                }
                else if ((item as BaseModel).EditedAt == (newItem as BaseModel).EditedAt)
                {
                    Items[Items.IndexOf(item)] = newItem;
                    data.Remove(item);
                }
            }

            foreach (Model item in data)
                Items.Add(item);

            IsRefreshing = false;
            IsBusy = false;
        }

        protected virtual async Task RefreshItems()
        {
            if (IsBusy)
                return;

            IsRefreshing = true;
            IsBusy = true;

            Items.Clear();

            foreach (var item in await KeyItemsService.GetItemsByKeyAsync(Id))
                Items.Add(item);

            IsBusy = false;
            IsRefreshing = false;
        }


        protected virtual async Task EditItem(Model item)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            await Shell.Current.GoToAsync($"{nameof(EditViewModel)}?Id={(item as BaseModel).Id}");
        }


        protected virtual async Task DeleteItem(Model item)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            if (await ItemService.DeleteItemAsync((item as BaseModel).Id))
                Items.Remove(item);

            IsBusy = false;
        }


        protected virtual async Task OpenItem(Model item)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await Shell.Current.GoToAsync($"{nameof(DisplayViewModel)}?Id={(item as BaseModel).Id}");
        }
    }
}
