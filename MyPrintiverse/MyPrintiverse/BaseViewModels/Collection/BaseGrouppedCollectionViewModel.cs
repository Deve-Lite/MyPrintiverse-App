using MyPrintiverse.Tools.Enums;

namespace MyPrintiverse.BaseViewModels.Collection;

/// <summary>
/// Base model for view with groupped CollectionView.
/// </summary>
/// <typeparam name="TBaseModel"> Model inheriting from BaseModel. </typeparam>
/// <typeparam name="TAdd"> Class (View) adding model.</typeparam>
/// <typeparam name="TEdit"> Class (View) editing model.</typeparam>
/// <typeparam name="TDisplay"> Class (View) displaying model.</typeparam>
public class GroupedCollectionViewModel<TBaseModel, TAdd, TEdit, TDisplay> : BaseCollectionViewModel<TBaseModel, TAdd, TEdit, TDisplay> where TBaseModel : BaseModel
{
    public new ObservableCollection<GroupedItem<TBaseModel>> Items { get; set; }

    public GroupedCollectionViewModel(MessageService messagingService, IItemAsyncService<TBaseModel> itemsService) : base(messagingService, itemsService)
    {
    }

    protected internal override async void OnAppearing()
    {
        base.OnAppearing();
        Items = new ObservableCollection<GroupedItem<TBaseModel>>();
        IsBusy = false;

        RefreshItemsCommand = new AsyncCommand(RefreshItems, CanExecute);
        AddItemCommand = new AsyncCommand(AddItem, CanExecute);
        EditItemCommand = new AsyncCommand<TBaseModel>(EditItem, CanExecute);
        OpenItemCommand = new AsyncCommand<TBaseModel>(OpenItem, CanExecute);
        DeleteItemCommand = new AsyncCommand<TBaseModel>(DeleteItem, CanExecute);
        ItemOptionsCommand = new AsyncCommand<TBaseModel>(ItemOptions, CanExecute);

        await UpdateItemsOnAppearing();
    }

    protected override async Task UpdateItemsOnAppearing()
    {
        IsBusy = true;
        IsRefreshing = true;

        var data = (List<TBaseModel>)await ItemsService.GetItemsAsync();

        int i = 0;
        foreach (var group in new List<GroupedItem<TBaseModel>>(Items))
        {
            foreach (TBaseModel item in group)
            {
                var newItem = data.FirstOrDefault(x => x.Id == item.Id);

                if (newItem == null)
                {
                    int index = GetIndex(item);

                    if (index == -1)
                    {
                        // Loading Error Message
                        continue;
                    }

                    Items[index].Remove(item);
                }
                else if (newItem.EditedAt != item.EditedAt)
                {
                    int index = GetIndex(item);

                    if (index == -1)
                    {
                        // Loading Error Message
                        continue;
                    }

                    Items[index][Items[index].IndexOf(item)] = newItem;
                }
            }
        }

        foreach (TBaseModel item in data)
            AddToItems(item);

        IsBusy = false;
        IsRefreshing = false;
    }

    protected override async Task RefreshItems()
    {

        IsRefreshing = true;

        Items.Clear();

        foreach (var item in await ItemsService.GetItemsAsync())
            AddToItems(item);

        IsBusy = false;
        IsRefreshing = false;
    }

    protected virtual void AddToItems(TBaseModel item)
    {
        int x = GetIndex(item);
        if (x == -1)
        {
            ObservableCollection<TBaseModel> model = new ObservableCollection<TBaseModel>();
            model.Add(item);
            Items.Add(new GroupedItem<TBaseModel>(GetNewGroupName(item), model));
        }
        else
        {
            Items[x].Add(item);
        }
    }

    protected virtual void DeleteFromItems(TBaseModel item)
    {
        int index = GetIndex(item);

        if (index == -1)
        {
            // Loading Error Message
            return;
        }

        Items[index].Remove(item);
    }

    /// <summary>
    /// Method creates new group name. (MUST BE IMPLEMENTED EACH TIME)
    /// </summary>
    /// <param name="item"></param>
    /// <returns> New group name. </returns>
    protected virtual string GetNewGroupName(TBaseModel item)
    {
        throw new NotImplementedException("Method GetNewGroupName must be implemented.");
    }

    /// <summary>
    /// Method returns group index. (MUST BE IMPLEMENTED EACH TIME)
    /// </summary>
    /// <param name="item"></param>
    /// <returns> Group Index else -1. </returns>
    protected virtual int GetIndex(TBaseModel item)
    {
        throw new NotImplementedException("Method GetIndex must be implemented.");
    }
}

