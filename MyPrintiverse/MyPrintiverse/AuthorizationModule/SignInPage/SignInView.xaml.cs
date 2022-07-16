namespace MyPrintiverse.AuthorizationModule.SignInPage;

public partial class SignInView : ContentPage
{
	private SignInViewModel? ViewModel => BindingContext as SignInViewModel;

	public SignInView(SignInViewModel viewmodel)
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
