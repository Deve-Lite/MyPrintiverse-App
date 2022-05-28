using System;
using System.Collections.ObjectModel;
using MyPrintiverse.Base.Models;
using MyPrintiverse.Interfaces;

namespace MyPrintiverse.Base.ViewModels
{
    /// <summary>
    /// View model for displaying single Collection with base commands.
    /// </summary>
    /// <typeparam name="Model"></typeparam>
    /// <typeparam name="AddViewModel"></typeparam>
    /// <typeparam name="EditViewModel"></typeparam>
    /// <typeparam name="DisplayViewModel"></typeparam>
    public abstract class CollectionViewModel<Model, AddViewModel, EditViewModel, DisplayViewModel> : BaseViewModel
    {
        public ObservableCollection<Model> Items { get; set; }

        public Command RefreshItemsCommand { get; set; }
        public Command AddItemCommand { get; set; }

        public Command<Model> EditItemCommand { get; set; }
        public Command<Model> OpenItemCommand { get; set; }
        public Command<Model> DeleteItemCommand { get; set; }

        protected IItemAsyncService<Model> ItemService;

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();
            Items = new ObservableCollection<Model>();
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
            foreach (Model item in new List<Model>(Items))
            {
                Model newItem = data.First(x => (x as BaseModel).Id == (item as BaseModel).Id);

                if (newItem == null)
                {
                    Items.Remove(item);
                    data.Remove(item);
                }
                else if ((item as BaseModel).EditedAt == (newItem as BaseModel).EditedAt)
                {
                    Items[Items.IndexOf(item)] = newItem;
                    data.Remove(item);
                }
            }

            foreach (Model item in data)
                Items.Add(item);

        }

        protected virtual async void RefreshItems()
        {
            if (IsBusy)
                return;

            IsRefreshing = true;
            IsBusy = true;

            Items.Clear();

            foreach (var item in await ItemService.GetItemsAsync())
                Items.Add(item);

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
                Items.Remove(item);

            IsBusy = false;
        }


        protected virtual async void OpenItem(Model item)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await Shell.Current.GoToAsync($"{nameof(DisplayViewModel)}?Id={(item as BaseModel).Id}");
        }
    }
}

