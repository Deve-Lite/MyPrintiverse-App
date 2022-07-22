namespace MyPrintiverse.Authorization.RemindPassword;

public partial class RemindPasswordView : ContentPage
{
	private RemindPasswordViewModel? ViewModel => BindingContext as RemindPasswordViewModel;

	public RemindPasswordView(RemindPasswordViewModel viewmodel)
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