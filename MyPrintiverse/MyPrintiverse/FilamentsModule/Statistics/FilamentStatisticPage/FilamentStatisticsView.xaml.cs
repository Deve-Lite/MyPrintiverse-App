namespace MyPrintiverse.FilamentsModule.Statistics.FilamentStatisticPage;

public partial class FilamentStatisticsView : ContentPage
{
    private FilamentStatisticsViewModel ViewModel => BindingContext as FilamentStatisticsViewModel;

    public FilamentStatisticsView(FilamentStatisticsViewModel vm)
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