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
    #region List

    /// <summary>
    /// Searched collection of Items.
    /// </summary>
    public new ObservableCollection<GroupedItem<TBaseModel>> SearchedItems { get; set; }

    #endregion

    public GroupedCollectionViewModel(IMessageService messagingService, IItemService<TBaseModel> itemsService) : base(messagingService, itemsService)
    {
        SearchedItems = new ObservableCollection<GroupedItem<TBaseModel>>();
    }

    #region Overrides

    protected virtual void SearchItems(string query)
    {
        var filteredItems = Items.Where(item => MatchQuery(item, query));

        foreach (TBaseModel item in Items)
        {

            if (!filteredItems.Contains(item))
            {
                DeleteFromSearchedItems(item);
                continue;
            }

            int itemCollectionIndex = GetIndex(item);

            if(itemCollectionIndex == -1)
                AddToCollection(SearchedItems, item);
            else
            {
                if (!SearchedItems[itemCollectionIndex].Contains(item)) 
                {
                    SearchedItems[itemCollectionIndex].Add(item);
                }
            }
        }

    }

    protected override async Task UpdateCollectionsOnAppearing()
    {
        var data = (List<TBaseModel>)await ItemsService.GetItemsAsync();

        var collections = new List<GroupedItem<TBaseModel>>(SearchedItems);

        foreach (var collection in collections)
        {
            UpdateCollection(collection, data, false);
            if (collection.Count == 0)
                SearchedItems.Remove(collection);
        }

        foreach (var item in data)
            AddToCollection(SearchedItems, item);

        SortCollection(SearchedItems);
    }

    protected override async Task Refresh()
    {
        Items = (List<TBaseModel>) await ItemsService.GetItemsAsync();
        await RefreshCollection(SearchedItems, Items);
    }

    protected override void DeleteFromSearchedItems(TBaseModel item)
    {
        int itemCollectionIndex = GetIndex(item);

        if (itemCollectionIndex == -1)
            return;

        RemoveFromCollection(SearchedItems[itemCollectionIndex], item);

        if (SearchedItems[itemCollectionIndex].Count == 0)
            SearchedItems.Remove(SearchedItems[itemCollectionIndex]);
    }


    protected override void UpdateCollection(ObservableCollection<TBaseModel> collection, List<TBaseModel> items, bool addRemaingItems = true)
    {
        foreach (var oldItem in new List<TBaseModel>(collection))
        {
            var newItem = items.FirstOrDefault(x => x.Id == oldItem.Id);

            if (newItem == null)
            {
                RemoveFromCollection(collection, oldItem);
            }
            else if (oldItem.EditedAt != newItem.EditedAt)
            {
                if (GetNewGroupName(oldItem) == GetNewGroupName(newItem))
                {
                    EditInCollection(collection, newItem, oldItem);
                    items.Remove(newItem);
                }
                else
                {
                    collection.Remove(oldItem);
                }
            }
            else if (newItem.EditedAt == oldItem.EditedAt)
                items.Remove(newItem);
        }

        if (addRemaingItems)
        {
            foreach (TBaseModel item in items)
                AddToCollection(collection, item);
        }

        SortCollection(collection);
    }

    #endregion

    #region Virtual Methods

    protected virtual async Task RefreshCollection(ObservableCollection<GroupedItem<TBaseModel>> Collection, IEnumerable<TBaseModel> newItems)
    {
        IsRefreshing = true;

        Collection.Clear();

        foreach (var item in newItems)
            AddToCollection(Collection, item);

        SortCollection(Collection);

        IsRefreshing = false;

    }

    protected virtual void AddToCollection(ObservableCollection<GroupedItem<TBaseModel>> Collection, TBaseModel item)
    {
        int i = GetIndex(item);
        if (i == -1)
        {
            ObservableCollection<TBaseModel> newItems = new ObservableCollection<TBaseModel> { item };
            SearchedItems.Add(new GroupedItem<TBaseModel>(GetNewGroupName(item), newItems));
        }
        else
            SearchedItems[i].Add(item);
    }

    protected virtual void SortCollection(ObservableCollection<GroupedItem<TBaseModel>> Collection) => Collection.OrderBy(x => x.Name);

    #endregion

    #region Must Be Implemented

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

    #endregion
}

