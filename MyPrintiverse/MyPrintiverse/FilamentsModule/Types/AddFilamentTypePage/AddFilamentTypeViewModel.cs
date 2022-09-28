﻿using MyPrintiverse.Tools;

namespace MyPrintiverse.FilamentsModule.Types.AddFilamentTypePage;

public partial class AddFilamentTypeViewModel : ManageFilamentTypeViewModel
{
    public AddFilamentTypeViewModel(IMessageService messageService, IItemService<FilamentType> itemService, IToast toast) : base(messageService, itemService, toast)
    {
    }


    #region Overrides

    [RelayCommand]
    public override async Task NextStep() => await Next(AddItem);

    public async Task AddItem() => await ManageItem(async (spool) => { return await ItemService.AddItemAsync(spool); });

    #endregion
}