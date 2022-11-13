using CommunityToolkit.Maui.Views;
using MyPrintiverse.Templates.Popups;

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

    public static readonly BindableProperty ColorHexProperty = BindableProperty.Create(nameof(ColorHex), typeof(string), typeof(DisplayFilamentView), "", BindingMode.TwoWay, propertyChanged: OnColorHexChanged);
    public string ColorHex
    {
        get => (string)GetValue(ColorHexProperty);
        set => SetValue(ColorHexProperty, value);
    }

    private static void OnColorHexChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var displayFilament = (DisplayFilamentView)bindable;

        var color = Color.FromArgb(displayFilament.ColorHex);
        var rate = 0.2126 * color.Red + 0.7152 * color.Green + 0.0722 * color.Blue;
        displayFilament.colorLabel.TextColor = rate < 0.5 ? Color.FromArgb("E7E9EF") : Color.FromArgb("1F2432");
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
        colorLabel.TextColor = Color.FromArgb("E7E9EF");
	}
    private void NoteClicked(object sender, EventArgs e)
    {
        Shell.Current.ShowPopup(new DescriptionPopup(Description));
    }
}