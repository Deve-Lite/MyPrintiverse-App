namespace MyPrintiverse.FilamentsModule.Prints.EditPrintPage;

public partial class EditPrintView : ContentPage
{
	private EditPrintViewModel ViewModel => BindingContext as EditPrintViewModel;
    public EditPrintView(EditPrintViewModel vm)
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