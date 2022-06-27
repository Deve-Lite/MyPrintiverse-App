namespace MyPrintiverse.BaseViewModels.Collection
{
    public abstract class BaseCollectionWithItemViewModel<TBaseModel, TAdd, TEdit, TDispaly> : BaseCollectionViewModel<TBaseModel, TAdd, TEdit, TDispaly> where TBaseModel : IBaseModel
    {
        public TBaseModel Item { get; set; }

        IItemAsyncService<TBaseModel> ItemService;

        public BaseCollectionWithItemViewModel(MessageService messagingService, IItemAsyncService<TBaseModel> itemService, IItemAsyncService<TBaseModel> itemsService) : base(messagingService, itemsService)
        {
            ItemService = itemService;
        }
    }
}
