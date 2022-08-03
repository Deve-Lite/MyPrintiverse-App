namespace MyPrintiverse.FilamentsModule.Types.AddFilamentTypePage;

public class AddFilamentTypeViewModel : BaseAddItemViewModel<FilamentType>
{
    FilamentTypeMock _filamentTypeMock;
    public AddFilamentTypeViewModel(MessageService messageService, FilamentTypeService itemService, FilamentTypeMock filamentTypeMock) : base(messageService, itemService)
    {
        _filamentTypeMock= filamentTypeMock;
        AddItemCommand = new AsyncCommand(AddItem);
    }

    public override void OnAppearing()
    {
        base.OnAppearing();

        Task.Run(async () =>
        {
            await Task.Delay(DELAY);
            await ItemService.AddItemAsync(_filamentTypeMock.GenerateFilamentType());
        });
    }
}