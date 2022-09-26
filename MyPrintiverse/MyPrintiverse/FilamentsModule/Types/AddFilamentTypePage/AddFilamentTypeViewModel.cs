namespace MyPrintiverse.FilamentsModule.Types.AddFilamentTypePage;

public class AddFilamentTypeViewModel : BaseAddItemViewModel<FilamentType>
{
    FilamentTypeMock _filamentTypeMock;
    public AddFilamentTypeViewModel(IMessageService messageService, IItemService<FilamentType> itemService, FilamentTypeMock filamentTypeMock) : base(messageService, itemService)
    {
        _filamentTypeMock= filamentTypeMock;
    }

    public override void OnAppearing()
    {
        base.OnAppearing();

        //Task.Run(async () =>
        //{
        //    await Task.Delay(DELAY);
        //    await ItemService.AddItemAsync(_filamentTypeMock.GenerateFilamentType());
        //});
    }

    public override Task NextStep()
    {
        return base.NextStep();
    }


    public override Task StepBack()
    {
        return base.StepBack();
    }
}