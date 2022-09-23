namespace MyPrintiverse.FilamentsModule.Spools.EditSpoolPage;

public partial class EditSpoolView : ContentPage
{
    private EditSpoolViewModel? ViewModel => BindingContext as EditSpoolViewModel;

    public EditSpoolView(EditSpoolViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;

        // TODO: Animate Views
        // TODO: Think of animating StepDescription
        // TODO: Completed event for ValidatableEntry ( focuses next Entry/Editor )
        // TODO: Focus event for ValidatableEntry
        // TODO: Editor 3 characters and space problem
        // TODO: Switch to modal page (it is fucked up a bit)
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel?.OnAppearing();
    }
}