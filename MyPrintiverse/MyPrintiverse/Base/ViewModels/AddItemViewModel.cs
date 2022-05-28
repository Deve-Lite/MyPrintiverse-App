namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// Base view model for adding new item.
    /// </summary>
    /// <typeparam name="Model"></typeparam>
    public class AddItemViewModel<Model> : BaseViewModel
    {
        protected Model item;
        public Model Item { get => item; set => SetProperty(ref item, value); }

        public Command AddItemCommand { get; set; }

        protected IItemAsyncService<Model> ItemService;

        protected internal override void OnAppearing()
        {
            base.OnAppearing();

            AddItemCommand = new Command(AddItem);
        }


        public virtual async void AddItem()
        {
            if (IsBusy)
                return;

            // Open loading popup/ activity indicator
            IsRefreshing = true;
            IsBusy = true;

            if (await ItemService.AddItemAsync(Item))
            {
                await Shell.Current.GoToAsync("..");
            }

            IsRefreshing = false;
            IsBusy = false;
        }
    }
}

