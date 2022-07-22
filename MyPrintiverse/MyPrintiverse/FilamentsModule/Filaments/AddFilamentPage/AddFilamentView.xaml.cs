namespace MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;

public partial class AddFilamentView : ContentPage
{
    private AddFilamentViewModel? ViewModel => BindingContext as AddFilamentViewModel;
    public AddFilamentView(AddFilamentViewModel vm)
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