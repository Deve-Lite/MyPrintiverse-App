
namespace MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;

[QueryProperty(nameof(Id),nameof(Id))]
public class AddSpoolViewModel : BaseAddItemViewModel<Spool>
{
    #region Fields

    public string Id { get; set; }

    #endregion

    SpoolMock SpoolMock;
    public AddSpoolViewModel(MessageService messageService, SpoolService itemService, SpoolMock spoolMock) : base(messageService, itemService)
	{
        SpoolMock = spoolMock;
    }

    public override async void OnAppearing()
    {
        base.OnAppearing();
        await ItemService.AddItemAsync(SpoolMock.GenerateSpool(Id));
    }
}