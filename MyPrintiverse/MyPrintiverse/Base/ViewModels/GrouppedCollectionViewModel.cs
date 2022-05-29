namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// Base model for view with groupped CollectionView.
    /// </summary>
    /// <typeparam name="T"> Collection model. </typeparam>
    /// <typeparam name="TAdd"> Class (View) adding model.</typeparam>
    /// <typeparam name="TEdit"> Class (View) editing model.</typeparam>
    /// <typeparam name="TDisplay"> Class (View) displaying model.</typeparam>
	public class GroupedCollectionViewModel<T, TAdd, TEdit, TDisplay> : BaseViewModel where T : BaseModel
    {
        public ObservableCollection<GrouppedItem<T>> Items { get; set; }

        public AsyncCommand RefreshItemsCommand { get; set; }
        public AsyncCommand AddItemCommand { get; set; }

        public AsyncCommand<T> EditItemCommand { get; set; }
        public AsyncCommand<T> OpenItemCommand { get; set; }
        public AsyncCommand<T> DeleteItemCommand { get; set; }

        protected IItemAsyncService<T> ItemsService;

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();
            Items = new ObservableCollection<GrouppedItem<T>>();
            IsBusy = false;

            RefreshItemsCommand = new AsyncCommand(RefreshItems,CanExecute);
            AddItemCommand = new AsyncCommand(AddItem, CanExecute);
            EditItemCommand = new AsyncCommand<T>(EditItem, CanExecute);
            OpenItemCommand = new AsyncCommand<T>(OpenItem, CanExecute);
            DeleteItemCommand = new AsyncCommand<T>(DeleteItem, CanExecute);

            await UpdateItemsOnAppearing();
        }

        protected virtual async Task AddItem() => await Shell.Current.GoToAsync($"{nameof(TAdd)}");

        protected virtual async Task UpdateItemsOnAppearing()
        {
            IsBusy = true;
            IsRefreshing = true;

            List<T> data = (List<T>)await ItemsService.GetItemsAsync();

            int i = 0;
            foreach (GrouppedItem<T> group in new List<GrouppedItem<T>>(Items))
            {
                foreach (T item in group)
                {
                    T newItem = data.FirstOrDefault(x => x.Id == item.Id);

                    if (newItem == null)
                    {
                        int x = GetIndex(item);
                        Items[x].Remove(item);
                    }
                    else if (newItem.EditedAt != item.EditedAt)
                    {
                        int x = GetIndex(item);
                        Items[x][Items[x].IndexOf(item)] = newItem;
                    }
                }
            }

            foreach (T item in data)
                AddToItems(item);

            IsBusy = false;
            IsRefreshing = false;
        }

        protected virtual async Task RefreshItems()
        {

            IsRefreshing = true;

            Items.Clear();

            foreach (T item in await ItemsService.GetItemsAsync())
                AddToItems(item);

            IsBusy = false;
            IsRefreshing = false;
        }


        protected virtual async Task EditItem(T item) => await Shell.Current.GoToAsync($"{nameof(TEdit)}?Id={item.Id}");


        protected virtual async Task DeleteItem(T item)
        {

            if (await ItemsService.DeleteItemAsync(item.Id))
                await DeleteItem(item);

            IsBusy = false;
        }


        protected virtual async Task OpenItem(T item) => await Shell.Current.GoToAsync($"{nameof(TDisplay)}?Id={item.Id}");

        protected virtual void AddToItems(T item)
        {
            int x = GetIndex(item);
            if (x == -1)
            {
                ObservableCollection<T> model = new ObservableCollection<T>();
                model.Add(item);
                Items.Add(new GrouppedItem<T>(GetNewGroupName(item), model));
            }
            else
            {
                Items[x].Items.Add(item);
            }
        }

        protected virtual void DeleteFromItems(T item)
        {
            Items[GetIndex(item)].Items.Remove(item);
        }

        /// <summary>
        /// Method creates new group name. (MUST BE IMPLEMENTED EACH TIME)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual string GetNewGroupName(T item)
        {
            return "Error";
        }

        /// <summary>
        /// Method returns group index. (MUST BE IMPLEMENTED EACH TIME)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual int GetIndex(T item)
        {
            return 0;
        }
    }
}

