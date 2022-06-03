namespace MyPrintiverse.FilamentsModule.Filaments.FilamentPage;

public partial class FilamentView : ContentPage
{
    private FilamentViewModel ViewModel => BindingContext as FilamentViewModel;
    public FilamentView(FilamentViewModel vm)
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