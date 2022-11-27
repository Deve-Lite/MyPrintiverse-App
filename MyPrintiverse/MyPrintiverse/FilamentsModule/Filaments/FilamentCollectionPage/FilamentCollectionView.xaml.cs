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
        search.IsVisible = false;
        border.IsVisible = false;
        search.Text= "";
        base.OnAppearing();
		ViewModel?.OnAppearing();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        if (search.IsVisible)
        {
            border.IsVisible = false;
            search.IsVisible = false;
            ViewModel?.SearchItems("");
        }
        else
        {
            border.IsVisible = true;
            search.IsVisible = true;
        }
    }
}