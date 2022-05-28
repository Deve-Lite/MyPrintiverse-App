namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// Base view model for adding new item.
    /// </summary>
    /// <typeparam name="Model"></typeparam>
    public class AddItemViewModel<Model> : BaseViewModel
    {
        protected Model item;
        public Model Item { get => item; set => SetProperty(ref item, value, OnChanged); }

        public AsyncCommand AddItemCommand { get; set; }

        protected IItemAsyncService<Model> ItemService;

        protected internal override void OnAppearing()
        {
            base.OnAppearing();

            AddItemCommand = new AsyncCommand(AddItem);
        }


        public virtual async Task AddItem()
        {
            if (IsBusy)
                return;

            // Open loading popup/ activity indicator

            IsBusy = true;

            if (await ItemService.AddItemAsync(Item))
                await Shell.Current.GoToAsync("..");
            

            IsBusy = false;
        }

        protected virtual void OnChanged()
        {

        }
    }
}

