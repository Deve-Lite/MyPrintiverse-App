using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MyPrintiverse.Admin;

public partial class AdminViewModel : BaseViewModel
{
	private readonly IAdminService _adminService;

	[ObservableProperty] 
	private string? _testText;

	public AdminViewModel(IAdminService adminService)
	{
		_adminService = adminService;
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

}