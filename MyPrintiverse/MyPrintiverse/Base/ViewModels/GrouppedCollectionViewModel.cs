namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// Base model for view with groupped CollectionView.
    /// </summary>
    /// <typeparam name="TBaseModel"> Model inheriting from BaseModel. </typeparam>
    /// <typeparam name="TAdd"> Class (View) adding model.</typeparam>
    /// <typeparam name="TEdit"> Class (View) editing model.</typeparam>
    /// <typeparam name="TDisplay"> Class (View) displaying model.</typeparam>
	public class GroupedCollectionViewModel<TBaseModel, TAdd, TEdit, TDisplay> : BaseViewModel where TBaseModel : BaseModel
    {
        public ObservableCollection<GrouppedItem<TBaseModel>> Items { get; set; }

        public AsyncCommand RefreshItemsCommand { get; set; }
        public AsyncCommand AddItemCommand { get; set; }

        public AsyncCommand<TBaseModel> EditItemCommand { get; set; }
        public AsyncCommand<TBaseModel> OpenItemCommand { get; set; }
        public AsyncCommand<TBaseModel> DeleteItemCommand { get; set; }

        protected IItemAsyncService<TBaseModel> ItemsService;

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();
            Items = new ObservableCollection<GrouppedItem<TBaseModel>>();
            IsBusy = false;

            RefreshItemsCommand = new AsyncCommand(RefreshItems,CanExecute);
            AddItemCommand = new AsyncCommand(AddItem, CanExecute);
            EditItemCommand = new AsyncCommand<TBaseModel>(EditItem, CanExecute);
            OpenItemCommand = new AsyncCommand<TBaseModel>(OpenItem, CanExecute);
            DeleteItemCommand = new AsyncCommand<TBaseModel>(DeleteItem, CanExecute);

            await UpdateItemsOnAppearing();
        }

        protected virtual async Task AddItem() => await Shell.Current.GoToAsync($"{nameof(TAdd)}");

        protected virtual async Task UpdateItemsOnAppearing()
        {
            IsBusy = true;
            IsRefreshing = true;

            List<TBaseModel> data = (List<TBaseModel>)await ItemsService.GetItemsAsync();

            int i = 0;
            foreach (GrouppedItem<TBaseModel> group in new List<GrouppedItem<TBaseModel>>(Items))
            {
                foreach (TBaseModel item in group)
                {
                    TBaseModel newItem = data.FirstOrDefault(x => x.Id == item.Id);

                    if (newItem == null)
                    {
                        int index = GetIndex(item);

                        if (index == -1)
                        {
                            // Loading Error Message
                            continue;
                        }

                        Items[index].Remove(item);
                    }
                    else if (newItem.EditedAt != item.EditedAt)
                    {
                        int index = GetIndex(item);

                        if (index == -1)
                        {
                            // Loading Error Message
                            continue;
                        }

                        Items[index][Items[index].IndexOf(item)] = newItem;
                    }
                }
            }

            foreach (TBaseModel item in data)
                AddToItems(item);

            IsBusy = false;
            IsRefreshing = false;
        }

        protected virtual async Task RefreshItems()
        {

            IsRefreshing = true;

            Items.Clear();

            foreach (TBaseModel item in await ItemsService.GetItemsAsync())
                AddToItems(item);

            IsBusy = false;
            IsRefreshing = false;
        }


        protected virtual async Task EditItem(TBaseModel item) => await Shell.Current.GoToAsync($"{nameof(TEdit)}?Id={item.Id}");


        protected virtual async Task DeleteItem(TBaseModel item)
        {

            if (await ItemsService.DeleteItemAsync(item.Id))
                await DeleteItem(item);

            IsBusy = false;
        }


        protected virtual async Task OpenItem(TBaseModel item) => await Shell.Current.GoToAsync($"{nameof(TDisplay)}?Id={item.Id}");

        protected virtual void AddToItems(TBaseModel item)
        {
            int x = GetIndex(item);
            if (x == -1)
            {
                ObservableCollection<TBaseModel> model = new ObservableCollection<TBaseModel>();
                model.Add(item);
                Items.Add(new GrouppedItem<TBaseModel>(GetNewGroupName(item), model));
            }
            else
            {
                Items[x].Items.Add(item);
            }
        }

        protected virtual void DeleteFromItems(TBaseModel item)
        {
            int index = GetIndex(item);

            if (index == -1)
            {
                // Loading Error Message
                return;
            }

            Items[index].Items.Remove(item);
        }

        /// <summary>
        /// Method creates new group name. (MUST BE IMPLEMENTED EACH TIME)
        /// </summary>
        /// <param name="item"></param>
        /// <returns> New group name. </returns>
        protected virtual string GetNewGroupName(TBaseModel item)
        {
            return "Error";
        }

        /// <summary>
        /// Method returns group index. (MUST BE IMPLEMENTED EACH TIME)
        /// </summary>
        /// <param name="item"></param>
        /// <returns> Group Index else -1. </returns>
        protected virtual int GetIndex(TBaseModel item)
        {
            return 0;
        }
    }
}

