using MongoDB.Bson;
using MyPrintiverse.FilamentsModule.Types;
using System.Collections.ObjectModel;

namespace MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;

public class AddFilamentViewModel : BaseAddItemViewModel<Filament>
{
    private FilamentTypeService TypeService;

    public List<FilamentTypeSelector> FilamentTypes { get; set; }

    public AsyncCommand SelectColorCommand { get; set; }

    public AddFilamentViewModel(MessageService messageService, FilamentService itemService, FilamentTypeService typeService) : base(messageService, itemService)
    {
        var typeServiceExceptionMessage = GetExceptionMessage<BaseAddItemViewModel<Filament>>(nameof(typeService));
        TypeService = typeService ?? throw new ArgumentNullException(typeServiceExceptionMessage);

        SelectColorCommand = new AsyncCommand(SelectColor);
    }

    public override void OnAppearing()
    {
        base.OnAppearing();
        FilamentTypes = new List<FilamentTypeSelector>();
        IsEnabled = true;
        Item = new FilamentValidator();
        Task.Run(async () => { await LoadFilamentTypes(); });
    }

    private async Task SelectColor()
    {
        var colorHex = await MessageService.ShowPromptAsync("Temporary", "Pass color hex:", keyboard:Keyboard.Chat, placeholder:"fdd3de");

        if (string.IsNullOrEmpty(colorHex) || colorHex == "Cancel")
            return;

        (Item as FilamentValidator).ColorHex = colorHex;
    }

    private async Task LoadFilamentTypes()
    {
        var types = await TypeService.GetItemsAsync();

        foreach (var type in types)
            FilamentTypes.Append(new FilamentTypeSelector { TypeId = type.Id, ShortName = type.ShortName});
    }

    public override bool IsValid()
    {
        return Item.Validate();
    }
}

