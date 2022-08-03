namespace MyPrintiverse.FilamentsModule.Types.AddFilamentTypePage;

public partial class AddFilamentTypeView : ContentPage
{
    private AddFilamentTypeViewModel ViewModel => BindingContext as AddFilamentTypeViewModel;
    public AddFilamentTypeView(AddFilamentTypeViewModel vm)
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