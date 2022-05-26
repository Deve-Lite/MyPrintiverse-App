using System;
using MyPrintiverse.Interfaces;

namespace MyPrintiverse.Utils.Base
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class EditItemViewModel<Model> : BaseViewModel
	{
        public string Id { get; set; }

        protected Model item;
        public Model Item { get => item; set => SetProperty(ref item, value, OnChanged); }

        public Command AddItemCommand { get; set; }

        protected IItemAsyncService<Model> ItemService;

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            Item = await ItemService.GetItemAsync(Id);

            AddItemCommand = new Command(AddItem);
        }


        public virtual async void AddItem()
        {
            if (IsBusy)
                return;

            // Open loading popup / activity indicator
            IsRefreshing = true;
            IsBusy = true;

            if (await ItemService.UpdateItemAsync(Item))
            {
                await Shell.Current.GoToAsync("..");
            }

            IsRefreshing = false;
            IsBusy = false;
        }

        protected virtual void OnChanged()
        {

        }
    }
}

