using MyPrintiverse.Core.Services;
using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.ViewModels.Collections;

/// <summary>
/// ViewModel for view displaying collection with key service.
/// </summary>
/// <typeparam name="TBaseModel"> Model inheriting from BaseModel. </typeparam>
/// <typeparam name="TAddView"> Class (View) adding model.</typeparam>
/// <typeparam name="TEditView"> Class (View) editing model.</typeparam>
/// <typeparam name="TItemView"> Class (View) displaying model.</typeparam>
[QueryProperty(nameof(Id), nameof(Id))]
public class BaseKeyCollectionViewModel<TBaseModel, TAddView, TEditView, TItemView> : BaseCollectionViewModel<TBaseModel, TAddView, TEditView, TItemView> where TBaseModel : BaseModel
{
    #region Fields

    /// <summary>
    /// Storing previous page id.
    /// </summary>
    private string PrevId;

    /// <summary>
    /// Item id used for quering,
    /// </summary>
    public string Id { get; set; }

    #endregion

    #region Services

    /// <summary>
    /// Service of item with Key conneced operations.
    /// </summary>
    protected IItemKeyService<TBaseModel> KeyItemsService;

    #endregion

    public BaseKeyCollectionViewModel(IMessageService messagingService, IItemService<TBaseModel> itemsService, IItemKeyService<TBaseModel> keyItemsService) : base(messagingService, itemsService)
    {
        var keyItemServiceExceptionMessage = GetExceptionMessage<BaseKeyCollectionViewModel<TBaseModel, TAddView, TEditView, TItemView>>(nameof(itemsService));
        KeyItemsService = keyItemsService ?? throw new ArgumentNullException(keyItemServiceExceptionMessage);
    }

    #region Overrides

    protected override async Task UpdateItemsOnAppearing()
    {
        if (Id != PrevId || !string.IsNullOrEmpty(PrevId)) 
        {
            PrevId = Id;
            await RefreshItems();
        }

        List<TBaseModel> data = (List<TBaseModel>)await KeyItemsService.GetItemsByKeyAsync(Id);

        int i = 0;
        foreach (TBaseModel item in new List<TBaseModel>(Items))
        {
            TBaseModel newItem = data.First(x => x.Id == item.Id);

            if (newItem == null)
            {
                Items.Remove(item);
            }
            else if (item.EditedAt != newItem.EditedAt)
            {
                Items[Items.IndexOf(item)] = newItem;
                data.Remove(item);
            }
            else if (newItem.EditedAt == item.EditedAt)
                data.Remove(newItem);
        }

        foreach (TBaseModel item in data)
            Items.Add(item);
    }

    protected override async Task RefreshItems()
    {
        IsRefreshing = true;

        Items.Clear();

        foreach (var item in await KeyItemsService.GetItemsByKeyAsync(Id))
            Items.Add(item);

        IsRefreshing = false;
    }

    #endregion
}
