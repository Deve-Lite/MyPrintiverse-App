using MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;
using MyPrintiverse.FilamentsModule.Filaments.FilamentPage;
using MyPrintiverse.Tools.Mock;
using System.Collections.ObjectModel;
using MyPrintiverse.Tools;

namespace MyPrintiverse.FilamentsModule.Filaments.FilamentsPage;

public class FilamentsViewModel : GroupedCollectionViewModel<Filament, AddFilamentView, EditFilamentView, FilamentView>
{
	private bool _isEnabled;
	public bool IsEnabled { get => _isEnabled; set => SetProperty(ref _isEnabled, value); }

	public AsyncCommand SwapThemeCommand { get; }

	private ISettingsService SettingsService { get;}

	public async Task SwapTheme()
	{
		await Task.Run(() =>
		{
			SettingsService.AppTheme = SettingsService.AppTheme == AppTheme.Light ? AppTheme.Dark : AppTheme.Light;
		});
	}

	public FilamentsViewModel(IMessageService messagingService, FilamentService itemsService, ISettingsService settingsService) : base(messagingService, itemsService)
	{
		SettingsService = settingsService;
		Items = new ObservableCollection<GroupedItem<Filament>>();
		SwapThemeCommand = new AsyncCommand(SwapTheme);
	}

	public override void OnAppearing()
	{
		base.OnAppearing();
		IsEnabled = true;
	}

	protected override async Task AddItem()
	{
		await ItemsService.AddItemAsync(FilamentMock.GenerateFilament());
		await UpdateItemsOnAppearing();
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