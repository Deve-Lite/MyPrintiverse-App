using System;
using System.Collections.ObjectModel;
using MyPrintiverse.Base.Models;
using MyPrintiverse.Interfaces;

namespace MyPrintiverse.BaseViewModels.Collection;

/// <summary>
/// View model for displaying single Collection with base commands.
/// </summary>
/// <typeparam name="TBaseModel"> Model </typeparam>
/// <typeparam name="TAdd"> Class (View) adding model.</typeparam>
/// <typeparam name="TEdit"> Class (View) editing model.</typeparam>
/// <typeparam name="TDisplay"> Class (View) displaying model.</typeparam>
public abstract class CollectionViewModel<TBaseModel, TAdd, TEdit, TDisplay> : BaseViewModel where TBaseModel : BaseModel
{
    public ObservableCollection<TBaseModel> Items { get; set; }

    public AsyncCommand RefreshItemsCommand { get; set; }
    public AsyncCommand AddItemCommand { get; set; }

    public AsyncCommand<TBaseModel> EditItemCommand { get; set; }
    public AsyncCommand<TBaseModel> OpenItemCommand { get; set; }
    public AsyncCommand<TBaseModel> DeleteItemCommand { get; set; }

    protected IItemAsyncService<TBaseModel> ItemsService;

    protected internal override async void OnAppearing()
    {
        base.OnAppearing();

        RefreshItemsCommand = new AsyncCommand(RefreshItems, CanExecute);
        AddItemCommand = new AsyncCommand(AddItem, CanExecute);
        EditItemCommand = new AsyncCommand<TBaseModel>(EditItem, CanExecute);
        OpenItemCommand = new AsyncCommand<TBaseModel>(OpenItem, CanExecute);
        DeleteItemCommand = new AsyncCommand<TBaseModel>(DeleteItem, CanExecute);

        await UpdateItemsOnAppearing();
    }

    protected virtual async Task AddItem() => await Shell.Current.GoToAsync($"{typeof(TAdd).Name}");

    protected virtual async Task UpdateItemsOnAppearing()
    {
        IsBusy = true;
        IsRefreshing = true;

        List<TBaseModel> data = (List<TBaseModel>)await ItemsService.GetItemsAsync();

        int i = 0;
        foreach (TBaseModel item in new List<TBaseModel>(Items))
        {
            TBaseModel newItem = data.First(x => x.Id == item.Id);

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

        foreach (TBaseModel item in data)
            Items.Add(item);

        IsRefreshing = false;
        IsBusy = false;
    }

    protected virtual async Task RefreshItems()
    {

        IsRefreshing = true;

        Items.Clear();

        foreach (var item in await ItemsService.GetItemsAsync())
            Items.Add(item);

        IsBusy = false;
        IsRefreshing = false;
    }


    protected virtual async Task EditItem(TBaseModel item) => await Shell.Current.GoToAsync($"{typeof(TEdit).Name}?Id={item.Id}");


    protected virtual async Task DeleteItem(TBaseModel item)
    {

        if (await ItemsService.DeleteItemAsync(item.Id))
            Items.Remove(item);

        IsBusy = false;
    }


    protected virtual async Task OpenItem(TBaseModel item) => await Shell.Current.GoToAsync($"{typeof(TDisplay).Name}?Id={item.Id}");
}

