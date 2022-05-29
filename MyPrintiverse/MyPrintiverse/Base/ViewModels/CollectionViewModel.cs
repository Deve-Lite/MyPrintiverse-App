using System;
using System.Collections.ObjectModel;
using MyPrintiverse.Base.Models;
using MyPrintiverse.Interfaces;

namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// View model for displaying single Collection with base commands.
    /// </summary>
    /// <typeparam name="T"> Model </typeparam>
    /// <typeparam name="TAdd"> Class (View) adding model.</typeparam>
    /// <typeparam name="TEdit"> Class (View) editing model.</typeparam>
    /// <typeparam name="TDisplay"> Class (View) displaying model.</typeparam>
    public abstract class CollectionViewModel<T, TAdd, TEdit, TDisplay> : BaseViewModel where T : BaseModel
    {
        public ObservableCollection<T> Items { get; set; }

        public AsyncCommand RefreshItemsCommand { get; set; }
        public AsyncCommand AddItemCommand { get; set; }

        public AsyncCommand<T> EditItemCommand { get; set; }
        public AsyncCommand<T> OpenItemCommand { get; set; }
        public AsyncCommand<T> DeleteItemCommand { get; set; }

        protected IItemAsyncService<T> ItemService;

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            RefreshItemsCommand = new AsyncCommand(RefreshItems, CanExecute);
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

            List<T> data = (List<T>)await ItemService.GetItemsAsync();

            int i = 0;
            foreach (T item in new List<T>(Items))
            {
                T newItem = data.First(x => x.Id == item.Id);

                if (newItem == null)
                {
                    Items.Remove(item);
                    data.Remove(item);
                }
                else if (item.EditedAt == newItem.EditedAt)
                {
                    Items[Items.IndexOf(item)] = newItem;
                    data.Remove(item);
                }
            }

            foreach (T item in data)
                Items.Add(item);

            IsRefreshing = false;
            IsBusy = false;
        }

        protected virtual async Task RefreshItems()
        {

            IsRefreshing = true;

            Items.Clear();

            foreach (var item in await ItemService.GetItemsAsync())
                Items.Add(item);

            IsBusy = false;
            IsRefreshing = false;
        }


        protected virtual async Task EditItem(T item) => await Shell.Current.GoToAsync($"{nameof(TEdit)}?Id={item.Id}");


        protected virtual async Task DeleteItem(T item)
        {

            if (await ItemService.DeleteItemAsync(item.Id))
                Items.Remove(item);

            IsBusy = false;
        }


        protected virtual async Task OpenItem(T item) => await Shell.Current.GoToAsync($"{nameof(TDisplay)}?Id={item.Id}");
    }
}

