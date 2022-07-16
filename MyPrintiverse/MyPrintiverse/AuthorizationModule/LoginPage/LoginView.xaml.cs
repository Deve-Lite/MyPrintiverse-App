#nullable enable

namespace MyPrintiverse.AuthorizationModule.LoginPage;

public partial class LoginView : ContentPage
{
	private LoginViewModel? ViewModel => BindingContext as LoginViewModel;

	public LoginView(LoginViewModel viewmodel)
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