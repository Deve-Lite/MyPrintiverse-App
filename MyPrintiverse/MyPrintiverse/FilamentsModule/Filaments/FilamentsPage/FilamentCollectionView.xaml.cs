namespace MyPrintiverse.FilamentsModule.Filaments.FilamentsPage;

public partial class FilamentCollectionView : ContentPage
{
    private FilamentsViewModel? ViewModel => BindingContext as FilamentsViewModel;
	public FilamentCollectionView(FilamentsViewModel vm)
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