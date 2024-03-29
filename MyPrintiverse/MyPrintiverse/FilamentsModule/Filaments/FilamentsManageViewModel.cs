﻿
using MyPrintiverse.FilamentsModule.Types;

namespace MyPrintiverse.FilamentsModule.Filaments;

public class FilamentsManageViewModel : BaseItemManageViewModel<Filament>
{
    private FilamentTypeService TypeService;
    public List<FilamentTypeSelector> FilamentTypes { get; set; }


    private FilamentTypeSelector selectedType;
    public FilamentTypeSelector SelectedType { get => selectedType; set => SetProperty(ref selectedType, value); }

    public AsyncCommand SelectColorCommand { get; set; }
    public FilamentsManageViewModel(MessageService messageService, FilamentService itemService, FilamentTypeService typeService) : base(messageService, itemService)
    {
        var typeServiceExceptionMessage = GetExceptionMessage<BaseAddItemViewModel<Filament>>(nameof(typeService));
        TypeService = typeService ?? throw new ArgumentNullException(typeServiceExceptionMessage);

        SelectColorCommand = new AsyncCommand(SelectColor);
    }

    public override void OnAppearing()
    {
        base.OnAppearing();
        IsEnabled = true;
        Task.Run(async () => { await LoadData(); });
    }

    protected virtual async Task LoadData()
    {
        Item = new FilamentValidator();
        await LoadFilamentTypes();
    }

    private async Task SelectColor()
    {
        var colorHex = await MessageService.ShowPromptAsync("Temporary", "Pass color hex:", keyboard: Keyboard.Chat, placeholder: "fdd3de", maxLength: 6);

        if (string.IsNullOrEmpty(colorHex) || colorHex == "Cancel")
            return;

        (Item as FilamentValidator).ColorHex = colorHex;
    }

    private async Task LoadFilamentTypes()
    {
        SelectedType = null;
        FilamentTypes = new List<FilamentTypeSelector>();
        var types = await TypeService.GetItemsAsync();

        foreach (var type in types)
            FilamentTypes.Add(new FilamentTypeSelector { TypeId = type.Id, ShortName = type.ShortName });

        if (types.Count()!=0)
            SelectedType = FilamentTypes[0];
    }

    public override bool IsValid()
    {
        return Item.Validate();
    }
}
