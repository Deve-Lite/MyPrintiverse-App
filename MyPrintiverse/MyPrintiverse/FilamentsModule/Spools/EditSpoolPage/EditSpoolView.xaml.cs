namespace MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;

public partial class EditSpoolView : ContentPage
{
    private EditSpoolViewModel ViewModel => BindingContext as EditSpoolViewModel;

    public EditSpoolView(EditSpoolViewModel vm)
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