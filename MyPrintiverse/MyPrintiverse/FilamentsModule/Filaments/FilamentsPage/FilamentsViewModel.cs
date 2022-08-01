using MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentPage;


namespace MyPrintiverse.FilamentsModule.Filaments.FilamentsPage;

public class FilamentsViewModel : GroupedCollectionViewModel<Filament, AddFilamentView, EditFilamentView, FilamentView>
{ 

    public FilamentsViewModel(MessageService messagingService, FilamentService itemsService) : base(messagingService, itemsService)
    {
        AddItemCommand = new AsyncCommand(AddItem, CanExecute, shellExecute:ExecuteBlockade);
    }

    public override void OnAppearing()
    {
        base.OnAppearing();
        IsEnabled = true;
    }

    protected override string GetNewGroupName(Filament item)
    {
        return item.Brand.Trim();
    }

    protected override int GetIndex(Filament item)
    {
        return Items.IndexOf(Items.FirstOrDefault(x => x.Name == item.Brand));
    }
}
