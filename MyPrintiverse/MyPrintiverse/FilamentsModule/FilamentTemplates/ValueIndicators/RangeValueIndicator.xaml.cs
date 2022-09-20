namespace MyPrintiverse.FilamentsModule.FilamentTemplates.ValueIndicators;

public partial class RangeValueIndicator : ContentView
{
    #region DisplayValue

    public static readonly BindableProperty DisplayValueStyleleProperty = BindableProperty.Create(nameof(DisplayValueStyle), typeof(Style), typeof(RangeValueIndicator), null);
    public Style DisplayValueStyle
    {
        get => (Style)GetValue(DisplayValueStyleleProperty);
        set => SetValue(DisplayValueStyleleProperty, value);
    }

    public static readonly BindableProperty DisplayValueProperty = BindableProperty.Create(nameof(DisplayValue), typeof(string), typeof(RangeValueIndicator), "Not set.");
    public string DisplayValue
    {
        get => (string)GetValue(DisplayValueProperty);
        set => SetValue(DisplayValueProperty, value);
    }

    #endregion

    #region Image

    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(RangeValueIndicator), "");
    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    #endregion

    #region 

    public static readonly BindableProperty SelectedFrameStyleProperty = BindableProperty.Create(nameof(SelectedFrameStyle), typeof(Style), typeof(RangeValueIndicator), null);
    public Style SelectedFrameStyle
    {
        get => (Style)GetValue(SelectedFrameStyleProperty);
        set => SetValue(SelectedFrameStyleProperty, value);
    }

    public static readonly BindableProperty UnselectedFrameStyleProperty = BindableProperty.Create(nameof(UnselectedFrameStyle), typeof(Style), typeof(RangeValueIndicator), null);
    public Style UnselectedFrameStyle
    {
        get => (Style)GetValue(UnselectedFrameStyleProperty);
        set => SetValue(UnselectedFrameStyleProperty, value);
    }

    #endregion

    public RangeValueIndicator()
	{
		InitializeComponent();
	}
}