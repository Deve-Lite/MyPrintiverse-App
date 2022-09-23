using Android.Net.IpSec.Ike.Exceptions;
using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.FilamentsModule.Filaments;
using MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;

namespace MyPrintiverse.FilamentsModule.Spools.SpoolPage;

[QueryProperty(nameof(FilamentId), nameof(FilamentId))]
public partial class SpoolViewModel : BaseItemViewModel<Spool, EditSpoolView>
{
    #region Properties
    public string FilamentId { get; set; }

	[ObservableProperty]
	public string _currency;

    [ObservableProperty]
	private Filament _itemFilament;

	protected IItemService<Filament> FilamentService;

	protected override string EditRoute => $"{nameof(EditSpoolView)}?Id={Item.Id}&FilamentId={FilamentId}";

    #endregion

    public SpoolViewModel(IMessageService messagingService, IItemService<Spool> itemService, IItemService<Filament> filamentService) : base(messagingService, itemService)
	{
		FilamentService = filamentService;
    }

	#region Overides

	public override void OnAppearing()
	{
		base.OnAppearing();

		Task.Run(async () => { ItemFilament = await FilamentService.GetItemAsync(FilamentId); });

        // TODO Load From Settings
        Currency = "PLN";
    }

	#endregion
}