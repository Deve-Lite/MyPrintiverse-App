namespace MyPrintiverse.AuthorizationModule.ChangePasswordPage;

public partial class ChangePasswordView : ContentPage
{
	private ChangePasswordViewModel? ViewModel => BindingContext as ChangePasswordViewModel;

	public ChangePasswordView(ChangePasswordViewModel viewmodel)
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