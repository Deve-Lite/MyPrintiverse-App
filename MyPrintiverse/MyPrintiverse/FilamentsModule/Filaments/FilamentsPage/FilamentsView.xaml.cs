namespace MyPrintiverse.FilamentsModule.Filaments.FilamentsPage;

public partial class FilamentsView : ContentPage
{
    private FilamentsViewModel? ViewModel => BindingContext as FilamentsViewModel;
	public FilamentsView(FilamentsViewModel vm)
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