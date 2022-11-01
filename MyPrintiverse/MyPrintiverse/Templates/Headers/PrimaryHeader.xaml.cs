namespace MyPrintiverse.Templates.Headers;

public partial class PrimaryHeader : ContentView
{
    #region Title

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(PrimaryHeader), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    public PrimaryHeader()
	{
		InitializeComponent();
	}
}