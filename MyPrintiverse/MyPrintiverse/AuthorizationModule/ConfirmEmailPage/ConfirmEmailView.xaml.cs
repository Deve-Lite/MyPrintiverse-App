namespace MyPrintiverse.AuthorizationModule.ConfirmEmailPage;

public partial class ConfirmEmailView : ContentPage
{
	private ConfirmEmailViewModel? ViewModel => BindingContext as ConfirmEmailViewModel;

	public ConfirmEmailView(ConfirmEmailViewModel viewmodel)
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