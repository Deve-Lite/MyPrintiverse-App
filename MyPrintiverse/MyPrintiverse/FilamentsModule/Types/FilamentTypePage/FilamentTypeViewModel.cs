﻿using MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;

namespace MyPrintiverse.FilamentsModule.Types.FilamentTypePage;

public class FilamentTypeViewModel : BaseItemViewModel<FilamentType, EditFilamentTypeView>
{
	public FilamentTypeViewModel(IMessageService messageService, IItemService<FilamentType> itemService) : base(messageService,itemService)
	{
            
	}
}