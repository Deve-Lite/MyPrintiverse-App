namespace MyPrintiverse.Admin;

public partial class AdminView : ContentPage
{
	private AdminViewModel? ViewModel => BindingContext as AdminViewModel;
	public AdminView(AdminViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		ViewModel?.OnAppearing();
	}
}