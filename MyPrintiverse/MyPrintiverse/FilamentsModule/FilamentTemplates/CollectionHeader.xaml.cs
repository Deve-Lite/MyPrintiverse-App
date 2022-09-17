namespace MyPrintiverse.FilamentsModule.FilamentTemplates;

public partial class CollectionHeader : ContentView
{
    #region Title

    public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle), typeof(Style), typeof(CollectionHeader), null);
    public Style TitleStyle
    {
        get => (Style)GetValue(TitleStyleProperty);
        set => SetValue(TitleStyleProperty, value);
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(CollectionHeader), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region StackLayout

    public static readonly BindableProperty StackLayoutStyleProperty = BindableProperty.Create(nameof(StackLayoutStyle), typeof(Style), typeof(CollectionHeader), null);
    public Style StackLayoutStyle
    {
        get => (Style)GetValue(StackLayoutStyleProperty);
        set => SetValue(StackLayoutStyleProperty, value);
    }

    #endregion

    public CollectionHeader()
	{
		InitializeComponent();
	}
}