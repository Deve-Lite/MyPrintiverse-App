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
        KeyItemsService = keyItemsService;
    }

    #region Overrides

    protected override async Task UpdateCollectionsOnAppearing()
    {
        if (Id != PrevId || !string.IsNullOrEmpty(PrevId)) 
        {
            PrevId = Id;
            Items.Clear();
            RefreshCollection(Items, (List<TBaseModel>)await KeyItemsService.GetItemsByKeyAsync(Id), false);
        }
        else
            UpdateCollection(Items, (List<TBaseModel>)await KeyItemsService.GetItemsByKeyAsync(Id));
    }

    protected override async Task Refresh()
    {
        RefreshCollection(Items, await KeyItemsService.GetItemsByKeyAsync(Id));
    }

    #endregion
}
