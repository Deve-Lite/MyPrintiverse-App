namespace MyPrintiverse.FilamentsModule.Filaments.EditFilamentPage;

public partial class EditFilamentView : ContentPage
{
    private EditFilamentViewModel? ViewModel => BindingContext as EditFilamentViewModel;
    public EditFilamentView(EditFilamentViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

        brandEntry.Completed += (s, e) => tagEntry.Focus();
        tagEntry.Completed += (s, e) => diameterEntry.Focus();
        colorEntry.Completed += (s, e) => colorPicker.Focus();

        nozzleTemperatureEntry.Completed += (s, e) => bedTemperatureEntry.Focus();
        bedTemperatureEntry.Completed += (s, e) => coolingRateEntry.Focus();
        coolingRateEntry.Completed += (s, e) => selector.Focus();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel?.OnAppearing();
    }
}