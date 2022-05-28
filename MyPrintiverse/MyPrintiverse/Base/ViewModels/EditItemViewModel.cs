namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// Base view model for editing any item.
    /// </summary>
    /// <typeparam name="Model"></typeparam>
    [QueryProperty(nameof(Id), nameof(Id))]
    public class EditItemViewModel<Model> : BaseViewModel
    {
        public string Id { get; set; }

        protected Model item;
        public Model Item { get => item; set => SetProperty(ref item, value, OnChanged); }

        public AsyncCommand AddItemCommand { get; set; }

        protected IItemAsyncService<Model> ItemService;

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            Item = await ItemService.GetItemAsync(Id);

            AddItemCommand = new AsyncCommand(EditItem);
        }


        public virtual async Task EditItem()
        {
            if (IsBusy)
                return;

            // Open loading popup / activity indicator
            IsBusy = true;

            if (await ItemService.UpdateItemAsync(Item))
                await Shell.Current.GoToAsync("..");
            

            IsBusy = false;
        }

        protected virtual void OnChanged()
        {

        }
    }
}

