namespace MyPrintiverse.FilamentsModule.Filaments.FilamentTemplates;

public partial class DisplayFilamentView : ContentView
{
    #region TextFields
    public static readonly BindableProperty BrandProperty = BindableProperty.Create(nameof(Brand), typeof(string), typeof(DisplayFilamentView), "");
    public string Brand
    {
        get => (string)GetValue(BrandProperty);
        set => SetValue(BrandProperty, value);
    }

    public static readonly BindableProperty TypeIdProperty = BindableProperty.Create(nameof(TypeId), typeof(string), typeof(DisplayFilamentView), "");
    public string TypeId
    {
        get => (string)GetValue(TypeIdProperty);
        set => SetValue(TypeIdProperty, value);
    }

    public static readonly BindableProperty ColorNameProperty = BindableProperty.Create(nameof(ColorName), typeof(string), typeof(DisplayFilamentView), "");
    public string ColorName
    {
        get => (string)GetValue(ColorNameProperty);
        set => SetValue(ColorNameProperty, value);
    }

    public static readonly BindableProperty ColorHexProperty = BindableProperty.Create(nameof(ColorHex), typeof(string), typeof(DisplayFilamentView), "");
    public string ColorHex
    {
        get => (string)GetValue(ColorHexProperty);
        set => SetValue(ColorHexProperty, value);
    }

    public static readonly BindableProperty DiameterProperty = BindableProperty.Create(nameof(Diameter), typeof(string), typeof(DisplayFilamentView), "");
    public string Diameter
    {
        get => (string)GetValue(DiameterProperty);
        set => SetValue(DiameterProperty, value);
    }

    #endregion

    #region Prtint settings

    public static readonly BindableProperty NozzleTemperatureProperty = BindableProperty.Create(nameof(NozzleTemperature), typeof(string), typeof(DisplayFilamentView), "");
    public string NozzleTemperature
    {
        get => (string)GetValue(NozzleTemperatureProperty);
        set => SetValue(NozzleTemperatureProperty, value);
    }

    public static readonly BindableProperty BedTemperatureProperty = BindableProperty.Create(nameof(BedTemperature), typeof(string), typeof(DisplayFilamentView), "");
    public string BedTemperature
    {
        get => (string)GetValue(BedTemperatureProperty);
        set => SetValue(BedTemperatureProperty, value);
    }

    public static readonly BindableProperty CoolingRateProperty = BindableProperty.Create(nameof(CoolingRate), typeof(string), typeof(DisplayFilamentView), "");
    public string CoolingRate
    {
        get => (string)GetValue(CoolingRateProperty);
        set => SetValue(CoolingRateProperty, value);
    }

    public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(DisplayFilamentView), "");
    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public static readonly BindableProperty EditedAtProperty = BindableProperty.Create(nameof(EditedAt), typeof(string), typeof(DisplayFilamentView), "");
    public string EditedAt
    {
        get => (string)GetValue(EditedAtProperty);
        set => SetValue(EditedAtProperty, value);
    }

    public static readonly BindableProperty CurrencyProperty = BindableProperty.Create(nameof(Currency), typeof(string), typeof(DisplayFilamentView), "");
    public string Currency
    {
        get => (string)GetValue(CurrencyProperty);
        set => SetValue(CurrencyProperty, value);
    }

    #endregion
    public DisplayFilamentView()
	{
		InitializeComponent();
	}
}