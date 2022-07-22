namespace MyPrintiverse.FilamentsModule.Types.FilamentTypePage;

public partial class FilamentTypeView : ContentPage
{
    private FilamentTypeViewModel? ViewModel => BindingContext as FilamentTypeViewModel;
    public FilamentTypeView(FilamentTypeViewModel vm)
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