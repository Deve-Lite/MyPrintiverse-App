namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// Base model for view with groupped CollectionView.
    /// </summary>
    /// <typeparam name="Model"></typeparam>
    /// <typeparam name="GrouppedModel"></typeparam>
    /// <typeparam name="AddViewModel"></typeparam>
    /// <typeparam name="EditViewModel"></typeparam>
    /// <typeparam name="DisplayViewModel"></typeparam>
	public class GroupedCollectionViewModel<Model, GrouppedModel, AddViewModel, EditViewModel, DisplayViewModel> : BaseViewModel
    {
        public ObservableCollection<GrouppedItem<Model>> Items { get; set; }

        public Command RefreshItemsCommand { get; set; }
        public Command AddItemCommand { get; set; }

        public Command<Model> EditItemCommand { get; set; }
        public Command<Model> OpenItemCommand { get; set; }
        public Command<Model> DeleteItemCommand { get; set; }

        protected IItemAsyncService<Model> ItemService;

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();
            Items = new ObservableCollection<GrouppedItem<Model>>();
            IsBusy = false;

            RefreshItemsCommand = new Command(RefreshItems);
            AddItemCommand = new Command(AddItem);
            EditItemCommand = new Command<Model>(EditItem);
            OpenItemCommand = new Command<Model>(OpenItem);
            DeleteItemCommand = new Command<Model>(DeleteItem);

            await UpdateItemsOnAppearing();
        }

        protected virtual async void AddItem()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await Shell.Current.GoToAsync($"{nameof(AddViewModel)}");
        }

        protected virtual async Task UpdateItemsOnAppearing()
        {


            List<Model> data = (List<Model>)await ItemService.GetItemsAsync();

            int i = 0;
            foreach (GrouppedItem<Model> group in new List<GrouppedItem<Model>>(Items))
            {
                foreach (Model item in group)
                {
                    Model newItem = data.FirstOrDefault(x => (x as BaseModel).Id == (item as BaseModel).Id);

                    if (newItem == null)
                    {
                        int x = GetIndex(item);
                        Items[x].Remove(item);
                    }
                    else if ((newItem as BaseModel).EditedAt != (item as BaseModel).EditedAt)
                    {
                        int x = GetIndex(item);
                        Items[x][Items[x].IndexOf(item)] = newItem;
                    }
                }
            }


            foreach (Model item in data)
                AddToItems(item);

        }

        protected virtual async void RefreshItems()
        {
            if (IsBusy)
                return;

            IsRefreshing = true;
            IsBusy = true;

            Items.Clear();

            foreach (Model item in await ItemService.GetItemsAsync())
                AddToItems(item);

            IsBusy = false;
            IsRefreshing = false;
        }


        protected virtual async void EditItem(Model item)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            await Shell.Current.GoToAsync($"{nameof(EditViewModel)}?Id={(item as BaseModel).Id}");
        }


        protected virtual async void DeleteItem(Model item)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            if (await ItemService.DeleteItemAsync((item as BaseModel).Id))
                DeleteItem(item);

            IsBusy = false;
        }


        protected virtual async void OpenItem(Model item)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await Shell.Current.GoToAsync($"{nameof(DisplayViewModel)}?Id={(item as BaseModel).Id}");
        }

        protected virtual void AddToItems(Model item)
        {
            int x = GetIndex(item);
            if (x == -1)
            {
                ObservableCollection<Model> model = new ObservableCollection<Model>();
                model.Add(item);
                Items.Add(new GrouppedItem<Model>(GetNewGroupName(item), model));
            }
            else
            {
                Items[x].Items.Add(item);
            }
        }

        protected virtual void DeleteFromItems(Model item)
        {
            Items[GetIndex(item)].Items.Remove(item);
        }

        /// <summary>
        /// Method creates new group name. (MUST BE IMPLEMENTED EACH TIME)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual string GetNewGroupName(Model item)
        {
            
            return "Error";
        }

        /// <summary>
        /// Method returns group index. (MUST BE IMPLEMENTED EACH TIME)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual int GetIndex(Model item)
        {
            return 0;
        }
    }
}

