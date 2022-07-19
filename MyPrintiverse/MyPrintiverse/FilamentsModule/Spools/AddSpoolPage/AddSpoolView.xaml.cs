namespace MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;

public partial class AddSpoolView : ContentPage
{
	private AddSpoolViewModel ViewModel => BindingContext as AddSpoolViewModel;
    public AddSpoolView(AddSpoolViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.OnAppearing();
    }
}