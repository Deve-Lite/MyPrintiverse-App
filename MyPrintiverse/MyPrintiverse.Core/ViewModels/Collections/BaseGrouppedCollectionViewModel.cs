using MyPrintiverse.Core.Services;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.ViewModels.Collections;

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

    public GroupedCollectionViewModel(IMessageService messagingService, IItemService<TBaseModel> itemsService) : base(messagingService, itemsService)
    {
        Items = new ObservableCollection<GroupedItem<TBaseModel>>();
    }

    public override async void OnAppearing()
    {
        base.OnAppearing();

  
    }

    protected override async Task UpdateItemsOnAppearing()
    {
        var data = (List<TBaseModel>)await ItemsService.GetItemsAsync();

        var iterableItems = new List<GroupedItem<TBaseModel>>(Items);

        for (int i = 0; i < iterableItems.Count; i++) 
        {
            for (int j = 0; j < iterableItems[i].Count; j++)
            {
                var item = iterableItems[i][j];

                var newItem = data.FirstOrDefault(x => x.Id == item.Id);

                if (newItem == null)
                {
                    DeleteFromItems(item);
                }
                else if (newItem.EditedAt != item.EditedAt) 
                {
                    Items[i][Items[i].IndexOf(item)] = newItem;

                    data.Remove(newItem);
                }
                else if (newItem.EditedAt == item.EditedAt)
                    data.Remove(newItem);
            }
        }

        foreach (var item in data)
            AddToItems(item);

        SortGroups();

 
    }

    protected override async Task RefreshItems()
    {
        IsRefreshing = true;

        Items.Clear();

        foreach (var item in await ItemsService.GetItemsAsync())
            AddToItems(item);

        SortGroups();

        IsRefreshing = false;
    }

    /// <summary>
    /// Method adds item to collection as new group or to existing group.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void AddToItems(TBaseModel item)
    {
        int i = GetIndex(item);
        if (i == -1)
        {
            ObservableCollection<TBaseModel> newItems = new ObservableCollection<TBaseModel>();
            newItems.Add(item);
            Items.Add(new GroupedItem<TBaseModel>(GetNewGroupName(item), newItems));
        }
        else
            Items[i].Add(item);
    }

    /// <summary>
    /// Method deletes item from collection.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void DeleteFromItems(TBaseModel item)
    {
        int i = GetIndex(item);

        Items[i].Remove(item);

        if (Items[i].Count == 0)
            Items.Remove(Items[i]);
    }

    /// <summary>
    /// After updating or refreshing, list of Items is sorted by this function.
    /// </summary>
    protected virtual void SortGroups()
    {
        Items.OrderBy(x => x.Name);
    }

    /// <summary>
    /// Method creates item group name.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"> must be implemented each time </exception>
    protected virtual string GetNewGroupName(TBaseModel item) => throw new NotImplementedException("Method GetNewGroupName must be implemented.");

    /// <summary>
    /// Method returns item group index or -1 if group is not existing.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"> must be implemented each time  </exception>
    protected virtual int GetIndex(TBaseModel item) => throw new NotImplementedException("Method GetIndex must be implemented.");
}

