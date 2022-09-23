namespace MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;

public partial class AddSpoolView : ContentPage
{
	private AddSpoolViewModel? ViewModel => BindingContext as AddSpoolViewModel;
    public AddSpoolView(AddSpoolViewModel vm)
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