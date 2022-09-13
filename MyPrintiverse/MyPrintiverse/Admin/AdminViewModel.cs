using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.FilamentsModule.Filaments;
using MyPrintiverse.FilamentsModule.Spools;
using MyPrintiverse.FilamentsModule.Types;
namespace MyPrintiverse.Admin;

public partial class AdminViewModel : BaseViewModel
{
	private readonly IAdminService _adminService;
	private readonly IItemService<Filament> _filamentService;
    private readonly IItemService<Spool> _spoolService;
    private readonly IItemService<FilamentType> _filamentTypeService;


    [ObservableProperty] 
	private string? _testText;

	public AdminViewModel(IAdminService adminService, IItemService<Filament> filamentService, IItemService<Spool> spoolService, IItemService<FilamentType> filamentTypeService)
	{
		_adminService = adminService;
		_filamentTypeService = filamentTypeService;
		_spoolService = spoolService;

		_filamentService = filamentService;
    }

	[RelayCommand]
	public async Task TestApiConnection() => await _adminService.PingApi();

	[RelayCommand]
	private async Task ShowLoadedAssets()
	{
		var loadedAssets = await _adminService.GetAssets();

		var stringBuilder = new StringBuilder();
		loadedAssets.ForEach(asset => stringBuilder.AppendLine(asset));
		var message = stringBuilder.ToString();

		await _adminService.MessageService.ShowAlertAsync("Loaded Assets", message);

		await TestApiConnection();

    }

	[RelayCommand]
	private async Task OpenAndromeda() => await _adminService.OpenAndromeda();

	[RelayCommand]
	private async Task OpenOdyssey() => await _adminService.OpenOdyssey();

	[RelayCommand]
	private async Task OpenOrion() => await _adminService.OpenOrion();

	[RelayCommand]
	private async Task DoNothing() => await Task.Run(() => 1 + 1);

	[RelayCommand]
    private async Task DeleteFilamentTypes() => await _filamentTypeService.DeleteAllAsync();
    [RelayCommand]
    private async Task DeleteSpools() => await _spoolService.DeleteAllAsync();
    [RelayCommand]
	private async Task DeleteFilaments() => await _filamentService.DeleteAllAsync();

	[RelayCommand]
	private async Task Register()
	{
		await _adminService.Register("", "", "");
	}

	[RelayCommand]
    private async Task LogIn() => await _adminService.LogIn("psp515@wp.pl", "adminadmin");

    [RelayCommand]
    private async Task Confirm() => await _adminService.ConfirmMail("psp515@wp.pl", "125720");

    [RelayCommand]
	private async Task DeleteAll()
	{
		await DeleteSpools();
		await DeleteFilaments();
		await DeleteFilamentTypes();
    }

}