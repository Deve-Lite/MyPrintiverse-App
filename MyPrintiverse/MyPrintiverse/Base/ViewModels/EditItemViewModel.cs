namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// Base view model for editing any item.
    /// </summary>
    /// <typeparam name="T"> Model. </typeparam>
    [QueryProperty(nameof(Id), nameof(Id))]
    public class EditItemViewModel<T> : BaseViewModel
    {
        public string Id { get; set; }

        protected T item;
        public T Item { get => item; set => SetProperty(ref item, value, OnChanged); }

        public AsyncCommand AddItemCommand { get; set; }

        protected IItemAsyncService<T> ItemService;

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            Item = await ItemService.GetItemAsync(Id);

            AddItemCommand = new AsyncCommand(EditItem, CanExecute);
        }


        public virtual async Task EditItem()
        {

            // Open loading popup / activity indicator

            if (await ItemService.UpdateItemAsync(Item))
                await Shell.Current.GoToAsync("..");
            

            IsBusy = false;
        }

        protected virtual void OnChanged()
        {

        }
    }
}

