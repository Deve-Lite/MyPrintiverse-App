using CommunityToolkit.Maui.Views;
using MyPrintiverse.FilamentsModule.Types.AddFilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;
using MyPrintiverse.FilamentsModule.Types.FilamentTypePage;
using MyPrintiverse.Templates.Popups;

namespace MyPrintiverse.FilamentsModule.Types.FilamentTypesPage;

public partial class FilamentTypesViewModel : BaseCollectionViewModel<FilamentType, AddFilamentTypeView,EditFilamentTypeView, FilamentTypeView>
{
	public FilamentTypesViewModel(IMessageService messageService, IItemService<FilamentType> itemsService) : base(messageService, itemsService)
	{
    }

    [RelayCommand]
	public void SoftingPoint()
	{
        Shell.Current.ShowPopup(new DescriptionPopup("This value is representing temperature at which filament is softing and starts to change it's shapes.", "Softing Point"));
    }

    protected override bool MatchQuery(FilamentType item, string query)
    {
        return item.ShortName.Contains(query, StringComparison.CurrentCultureIgnoreCase) || item.FullName.Contains(query, StringComparison.CurrentCultureIgnoreCase);
    }
}