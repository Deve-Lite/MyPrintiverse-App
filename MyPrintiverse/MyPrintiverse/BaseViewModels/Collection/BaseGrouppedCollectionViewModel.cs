using MyPrintiverse.Tools.Enums;

namespace MyPrintiverse.BaseViewModels.Collection;

/// <summary>
/// View model for displaying groupped collection.
/// </summary>
/// <typeparam name="TBaseModel"> Model inheriting from BaseModel. </typeparam>
/// <typeparam name="TAddView"> Class (View) adding model.</typeparam>
/// <typeparam name="TEditView"> Class (View) editing model.</typeparam>
/// <typeparam name="TItemView"> Class (View) displaying model.</typeparam>
public class GroupedCollectionViewModel<TBaseModel, TAddView, TEditView, TItemView> : BaseCollectionViewModel<TBaseModel, TAddView, TEditView, TItemView> where TBaseModel : BaseModel
{
    /// <summary>
    /// Collection of groupped items (TBaseModel).
    /// </summary>
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


    /// <summary>
    /// Method adds item to collection as new group or to existing group.
    /// </summary>
    /// <param name="item"></param>
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

    /// <summary>
    /// Method deletes item from collection.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void DeleteFromItems(TBaseModel item)
    {
        int index = GetIndex(item);

        if (index == -1)
        {
            // Loading Error Message
            return;
        }

        Items[index].Remove(item);

        if (Items[index].Count == 0)
            Items.Remove(Items[index]);
    }

    /// <summary>
    /// Method creates item group name.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"> must be implemented each time </exception>
    protected virtual string GetNewGroupName(TBaseModel item)
    {
        throw new NotImplementedException("Method GetNewGroupName must be implemented.");
    }

    /// <summary>
    /// method returns item group index or -1 if group is not existing.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"> must be implemented each time  </exception>
    protected virtual int GetIndex(TBaseModel item)
    {
        throw new NotImplementedException("Method GetIndex must be implemented.");
    }
}

