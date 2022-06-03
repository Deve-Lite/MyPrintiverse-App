namespace MyPrintiverse.FilamentsModule.Prints.AddPrintPage;

public partial class AddPrintView : ContentPage
{
    private AddPrintViewModel ViewModel => BindingContext as AddPrintViewModel;
    public AddPrintView(AddPrintViewModel vm)
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