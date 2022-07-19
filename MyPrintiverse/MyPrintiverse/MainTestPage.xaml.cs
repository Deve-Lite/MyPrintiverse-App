namespace MyPrintiverse;

public partial class MainTestPage : ContentPage
{
	MainTestViewModel ViewModel => BindingContext as MainTestViewModel;

    public MainTestPage()
    {
        InitializeComponent();
    }

    public MainTestPage(MainTestViewModel viewModel) 
	{
		InitializeComponent();

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //ViewModel.OnAppearing();
    }
}