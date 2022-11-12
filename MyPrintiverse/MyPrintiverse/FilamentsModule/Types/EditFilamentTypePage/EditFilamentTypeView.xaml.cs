namespace MyPrintiverse.FilamentsModule.Types.EditFilamentTypePage;

public partial class EditFilamentTypeView : ContentPage
{
    private EditFilamentTypeViewModel? ViewModel => BindingContext as EditFilamentTypeViewModel;
    public EditFilamentTypeView(EditFilamentTypeViewModel vm)
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
        ViewModel?.OnAppearing();
    }
}