namespace MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;

public partial class EditFilamentView : ContentPage
{
    private EditFilamentViewModel? ViewModel => BindingContext as EditFilamentViewModel;
    public EditFilamentView(EditFilamentViewModel vm)
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