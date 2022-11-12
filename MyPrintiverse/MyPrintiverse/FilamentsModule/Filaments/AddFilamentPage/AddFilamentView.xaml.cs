namespace MyPrintiverse.FilamentsModule.Filaments.AddFilamentPage;

public partial class AddFilamentView : ContentPage
{
    private AddFilamentViewModel? ViewModel => BindingContext as AddFilamentViewModel;
    public AddFilamentView(AddFilamentViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        brandEntry.Completed += (s, e) => diameterEntry.Focus();
        diameterEntry.Completed += (s, e) => colorEntry.Focus();
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