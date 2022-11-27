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
        search.Text= "";
        border.IsVisible = false;
        search.IsVisible = false;
        ViewModel?.OnAppearing();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        if (search.IsVisible)
        {
            search.IsVisible = false;
            border.IsVisible = false;
            ViewModel?.SearchItems("");
        }
        else 
        {
            border.IsVisible = true;
            search.IsVisible = true;
        }
    }
}