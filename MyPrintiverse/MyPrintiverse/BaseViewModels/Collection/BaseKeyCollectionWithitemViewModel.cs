﻿using System;

namespace MyPrintiverse.BaseViewModels.Collection
{
    /// <summary>
    /// View Model for displaying item and collection of key service.
    /// </summary>
    /// <typeparam name="TBaseModel"> Model of displayed item </typeparam>
    /// <typeparam name="TCollectionModel"> Model inheriting from BaseModel. Displayed in Collection view </typeparam>
    /// <typeparam name="TCollectionAdd"> Class (View) adding item.</typeparam>
    /// <typeparam name="TEdit"> Class (View) editing item.</typeparam>
    /// <typeparam name="TCollectionDisplay"> Class (View) displaying collection item.</typeparam>
    public class BaseKeyCollectionWithitemViewModel<TBaseModel, TEdit, TCollectionModel, TCollectionEdit, TCollectionAdd, TCollectionDisplay> :
        BaseKeyCollectionViewModel<TCollectionModel, TCollectionAdd, TCollectionEdit, TCollectionDisplay> where TCollectionModel : BaseModel where TBaseModel : BaseModel
    {

        /// <summary>
        /// item backing storage.
        /// </summary>
        private TBaseModel item;
        /// <summary>
        /// Item for displaying 
        /// </summary>
        public TBaseModel Item { get => item; set => SetProperty(ref item, value); }

        /// <summary>
        /// Item id from querry.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Command for view, designed to open page with item edition.
        /// </summary>
        public AsyncCommand EditDisplayItemCommand { get; set; }
        /// <summary>
        /// Command for view, designed to delete item.
        /// </summary>
        public AsyncCommand DeleteDisplayItemCommand { get; set; }

        /// <summary>
        /// Service of diplayed Item.
        /// </summary>
        IItemAsyncService<TBaseModel> ItemService;

        public BaseKeyCollectionWithitemViewModel(MessageService messagingService, IItemAsyncService<TBaseModel> itemService, IItemAsyncService<TCollectionModel> itemsService, IItemKeyAsyncService<TCollectionModel> keyItemsService) : base(messagingService, itemsService, keyItemsService)
        {
            var keyItemServiceExceptionMessage = GetExceptionMessage<BaseKeyCollectionWithitemViewModel<TBaseModel, TEdit, TCollectionModel, TCollectionEdit, TCollectionAdd, TCollectionDisplay>>(nameof(itemsService));
            ItemService = itemService ?? throw new ArgumentNullException(keyItemServiceExceptionMessage);
        }

        protected internal override async void OnAppearing()
        {
            EditDisplayItemCommand = new AsyncCommand(EditDisplayItem, CanExecute);
            DeleteDisplayItemCommand = new AsyncCommand(DeleteDisplayItem, CanExecute);

            Item = await ItemService.GetItemAsync(Id);

            base.OnAppearing();
        }

        /// <summary>
        /// Task connected to EditDisplayItemCommand.
        /// </summary>
        /// <returns></returns>
        protected virtual async Task EditDisplayItem() => await Shell.Current.GoToAsync($"{typeof(TEdit).Name}", true);

        /// <summary>
        /// Task connected to DeleteDisplayedItemCommand. By default deletes only Item.
        /// </summary>
        /// <returns></returns>
        protected virtual async Task DeleteDisplayItem()
        {
            // make sure to delete
            if (await ItemService.DeleteItemAsync(Item.Id))
                await Shell.Current.GoToAsync("..", true);

            IsBusy = false;
        }
    }
}

