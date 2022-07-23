namespace MyPrintiverse.Templates.Test;

public partial class TestPage : ContentPage
{
    private TestViewModel ViewModel => BindingContext as TestViewModel;
    public TestPage(TestViewModel vm)
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