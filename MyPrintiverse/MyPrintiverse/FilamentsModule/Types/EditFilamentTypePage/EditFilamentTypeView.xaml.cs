namespace MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;

public partial class EditFilamentTypeView : ContentPage
{
    private EditFilamentTypeViewModel? ViewModel => BindingContext as EditFilamentTypeViewModel;
    public EditFilamentTypeView(EditFilamentTypeViewModel vm)
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