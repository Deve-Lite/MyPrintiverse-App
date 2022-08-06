using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Spools;
using MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;
using MyPrintiverse.FilamentsModule.Spools.SpoolPage;
using System.Collections.ObjectModel;

namespace MyPrintiverse.FilamentsModule.Filaments.FilamentPage;

public class FilamentViewModel : BaseKeyCollectionWithitemViewModel<Filament, EditFilamentView, Spool, AddSpoolView, EditSpoolView, SpoolView>
{
    public ObservableCollection<Filament> FinishedFilaments { get; set; } 

    public FilamentViewModel(MessageService messagingService, FilamentService itemService, SpoolService itemsService) : base(messagingService, itemService, itemsService, itemsService  )
    {
        FinishedFilaments = new ObservableCollection<Filament>();
    }


    #region Overrides

    protected override Task UpdateCollectionsOnAppearing()
    {
        return base.UpdateCollectionsOnAppearing();
    }

    protected override async Task AddItem() => await Shell.Current.GoToAsync($"{nameof(AddSpoolView)}?Id={Item.Id}");

    #endregion
}