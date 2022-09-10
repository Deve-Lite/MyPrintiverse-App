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
    /// Collection of groupped items (TBaseModel).
    /// </summary>
    public new ObservableCollection<GroupedItem<TBaseModel>> Items { get; set; }

    #endregion

    public GroupedCollectionViewModel(IMessageService messagingService, IItemService<TBaseModel> itemsService) : base(messagingService, itemsService)
    {
        Items = new ObservableCollection<GroupedItem<TBaseModel>>();
    }

    #region Overrides

    protected override async Task UpdateCollectionsOnAppearing()
    {
        var data = (List<TBaseModel>)await ItemsService.GetItemsAsync();

        var collections = new List<GroupedItem<TBaseModel>>(Items);

        foreach (var collection in collections)
        {
            UpdateCollection(collection, data, false);
            if (collection.Count == 0)
                Items.Remove(collection);
        }

        foreach (var item in data)
            AddToCollection(Items,item);

        SortCollection(Items);
    }

    protected override async Task Refresh()
    {
        await RefreshCollection(Items, await ItemsService.GetItemsAsync());
    }

    protected override void DeleteFromItems(TBaseModel item)
    {
        int itemCollectionIndex = GetIndex(item);

        RemoveFromCollection(Items[itemCollectionIndex], item);

        if (Items[itemCollectionIndex].Count == 0)
            Items.Remove(Items[itemCollectionIndex]);
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
            ObservableCollection<TBaseModel> newItems = new ObservableCollection<TBaseModel>();
            newItems.Add(item);
            Items.Add(new GroupedItem<TBaseModel>(GetNewGroupName(item), newItems));
        }
        else
            Items[i].Add(item);
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

