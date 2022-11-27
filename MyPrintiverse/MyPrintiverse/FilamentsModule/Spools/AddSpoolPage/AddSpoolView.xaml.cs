namespace MyPrintiverse.FilamentsModule.Spools.AddSpoolPage;

public partial class AddSpoolView : ContentPage
{
	private AddSpoolViewModel? ViewModel => BindingContext as AddSpoolViewModel;
    public AddSpoolView(AddSpoolViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

        costEntry.Completed += (s, e) => standardWeightEntry.Focus();
        standardWeightEntry.Completed += (s, e) => avaliableWeightEntry.Focus();
        avaliableWeightEntry.Completed += (s, e) => tagEntry.Focus();
        tagEntry.Completed += (s, e) => descriptionEditor.Focus();

        // TODO: Animate Views
        // TODO: Editor 3 characters and space problem
        // TODO: Switch to modal page (it is fucked up a bit)
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel?.OnAppearing();
    }
}