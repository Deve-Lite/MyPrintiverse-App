
namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// Base ViewModel for View displaying Item.
    /// </summary>
    /// <typeparam name="TBaseModel"> Model inheriting from BaseModel. </typeparam>
    /// <typeparam name="TEdit"> Class (View) editing model. </typeparam>
    [QueryProperty(nameof(Id), nameof(Id))]
    public class DisplayItemViewModel<TBaseModel, TEdit> : BaseViewModel
    {
        private TBaseModel item;
        public TBaseModel Item { get => item; set => SetProperty(ref item, value); }

        public AsyncCommand EditItemCommand { get; set; }
        public AsyncCommand DeleteItemCommand { get; set; }

        public string Id { get; set; }

        protected IItemAsyncService<TBaseModel> ItemService { get; set; }

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            EditItemCommand = new AsyncCommand(EditItem, CanExecute);
            DeleteItemCommand = new AsyncCommand(DeleteItem, CanExecute);

            Item = await ItemService.GetItemAsync(Id);
        }


        protected virtual async Task EditItem() => await Shell.Current.GoToAsync($"{typeof(TEdit).Name}");

        protected virtual async Task DeleteItem()
        {

            if (await ItemService.DeleteItemAsync(Id))
                await Shell.Current.GoToAsync("..");

            IsBusy = false;
        }

    }
}
