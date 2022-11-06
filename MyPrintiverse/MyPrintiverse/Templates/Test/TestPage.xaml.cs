namespace MyPrintiverse.Templates.Test;

public partial class TestPage : ContentPage
{
    private TestViewModel ViewModel => BindingContext as TestViewModel;
    public TestPage(TestViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        //e1.Completed += (s,e) => e2.Focus();
        //en1.Completed += (s, e) => en2.Focus(); 
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.OnAppearing();
    }
}