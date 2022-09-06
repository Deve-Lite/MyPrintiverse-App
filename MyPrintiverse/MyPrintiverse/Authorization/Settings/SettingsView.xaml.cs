namespace MyPrintiverse.Authorization.Settings;

public partial class SettingsView : ContentPage
{
	private SettingsViewModel? ViewModel => BindingContext as SettingsViewModel;

	public SettingsView(SettingsViewModel viewmodel)
	{
		BindingContext = viewmodel;

		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		ViewModel?.OnAppearing();
	}
}