namespace MyPrintiverse.FilamentsModule.Types.AddFilamentTypePage;

public partial class AddFilamentTypeView : ContentPage
{
    private AddFilamentTypeViewModel ViewModel => BindingContext as AddFilamentTypeViewModel;
    public AddFilamentTypeView(AddFilamentTypeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        shortNameEntry.Completed += (s, e) => nameEntry.Focus();
        nameEntry.Completed += (s, e) => descriptionEditor.Focus();


        densityEntry.Completed += (s, e) => maxServiceEntry.Focus();
        maxServiceEntry.Completed += (s, e) => nozzleRangeEntry.Focus();
        nozzleRangeEntry.RCompleted += (s, e) => bedRangeEntry.Focus();
        bedRangeEntry.RCompleted += (s, e) => coolingRangeEntry.Focus();
        coolingRangeEntry.RCompleted += (s, e) => descriptionEditor.Focus();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.OnAppearing();
    }
}