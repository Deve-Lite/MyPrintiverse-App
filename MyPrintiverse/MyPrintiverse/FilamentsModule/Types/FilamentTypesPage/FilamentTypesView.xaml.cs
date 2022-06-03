namespace MyPrintiverse.FilamentsModule.Types.FilamentTypesPage;

public partial class FilamentTypesView : ContentPage
{
	private FilamentTypesViewModel ViewModel => BindingContext as FilamentTypesViewModel;
    public FilamentTypesView(FilamentTypesViewModel vm)
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