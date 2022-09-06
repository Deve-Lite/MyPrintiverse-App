
namespace MyPrintiverse.FilamentsModule.Spools.SpoolPage;

public partial class SpoolView : ContentPage
{
	private SpoolViewModel? ViewModel => BindingContext as SpoolViewModel;

    public SpoolView(SpoolViewModel vm)
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