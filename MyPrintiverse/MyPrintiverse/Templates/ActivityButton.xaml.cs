namespace MyPrintiverse.Templates;

public partial class ActivityButton : ContentView
{
    #region FontSizeProperty

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(nameof(FontSize), typeof(int), typeof(ActivityButton), 16);
    public int FontSize
    {
        get => (int)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

	#endregion

	#region TextProperty

	public static readonly BindableProperty TextProperty =
		BindableProperty.Create(nameof(Text), typeof(string), typeof(ActivityButton), "Default text");
	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	#endregion

	#region CommandProperty

	public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ActivityButton), default(ICommand));
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    #endregion

    #region LoadingProperty

    public static readonly BindableProperty LoadingProperty =
        BindableProperty.Create(nameof(Loading), typeof(bool), typeof(ActivityButton), false);
    public bool Loading
    {
        get => (bool)GetValue(LoadingProperty);
        set => SetValue(LoadingProperty, value);
    }

    #endregion

    #region LoaderColorProperty

    public static readonly BindableProperty LoaderColorProperty =
        BindableProperty.Create(nameof(ActivityIndicatorColor), typeof(Color), typeof(ActivityButton), new Color(0));
    public Color ActivityIndicatorColor
    {
        get => (Color)GetValue(LoaderColorProperty);
        set => SetValue(LoaderColorProperty, value);
    }

    #endregion

    #region BorderWidthProperty

    public static readonly BindableProperty BorderWidthProperty =
        BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(ActivityButton), default(double));
    public double BorderWidth
    {
        get => (double)GetValue(BorderWidthProperty);
        set => SetValue(BorderWidthProperty, value);
    }

    #endregion

    #region BorderColorProperty

    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(ActivityButton), new Color(0));
    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }
    #endregion

    #region ButtonTextProperty

    public static readonly BindableProperty ButtonTextProperty =
        BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(ActivityButton), "Save");
    public string ButtonText
    {
        get => (string) GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }

    #endregion

    public ActivityButton()
	{
        InitializeComponent();
    }
}