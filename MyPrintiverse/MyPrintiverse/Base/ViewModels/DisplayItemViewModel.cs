
namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// Base ViewModel for View displaying Item.
    /// </summary>
    [QueryProperty(nameof(Id), nameof(Id))]
    public class DisplayItemViewModel<Model, EditViewModel> : BaseViewModel
    {
        Model item;
        public Model Item { get => item; set => SetProperty(ref item, value); }

        public AsyncCommand EditItemCommand { get; set; }
        public AsyncCommand DeleteItemCommand { get; set; }

        public string Id { get; set; }

        IItemAsyncService<Model> ItemService { get; set; }

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            EditItemCommand = new AsyncCommand(EditItem);
            DeleteItemCommand = new AsyncCommand(DeleteItem);

            Item = await ItemService.GetItemAsync(Id);
        }


        protected virtual async Task EditItem()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            await Shell.Current.GoToAsync($"{nameof(EditViewModel)}");
        }

        protected virtual async Task DeleteItem()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            if (await ItemService.DeleteItemAsync(Id))
                await Shell.Current.GoToAsync("..");

            IsBusy = false;
        }

    }
}
