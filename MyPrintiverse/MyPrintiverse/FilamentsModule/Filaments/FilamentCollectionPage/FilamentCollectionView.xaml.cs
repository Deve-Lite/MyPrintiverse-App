namespace MyPrintiverse.FilamentsModule.Filaments.FilamentCollectionPage;

public partial class FilamentCollectionView : ContentPage
{
    private FilamentCollectionViewModel? ViewModel => BindingContext as FilamentCollectionViewModel;
	public FilamentCollectionView(FilamentCollectionViewModel vm)
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