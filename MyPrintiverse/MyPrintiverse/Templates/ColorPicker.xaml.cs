namespace MyPrintiverse.Templates;

public partial class ColorPicker : ContentView
{
    public ColorPicker()
    {
        InitializeComponent();
        defaultModeSwitch.IsToggled = true;
    }

    #region Title

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(RangeValidatableEntry), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region ColorHex

    public static readonly BindableProperty ColorHexProperty = BindableProperty.Create(nameof(ColorHex), typeof(string), typeof(ColorPicker), "00000000", propertyChanged: OnColorHexChanged);
    public string ColorHex
    {
        get => (string)GetValue(ColorHexProperty);
        set => SetValue(ColorHexProperty, value);
    }

    public static readonly BindableProperty NewColorHexProperty = BindableProperty.Create(nameof(NewColorHex), typeof(string), typeof(ColorPicker), "00000000");
    public string NewColorHex
    {
        get => (string)GetValue(NewColorHexProperty);
        set => SetValue(NewColorHexProperty, value);
    }

    private static void OnColorHexChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var picker = (ColorPicker)bindable;

        string hex = picker.ColorHex;

        if (hex == null || hex.Length != 8)
            return;

        picker.aSlider.Value = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber) / 255;
        picker.rSlider.Value = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        picker.gSlider.Value = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        picker.bSlider.Value = int.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
    }

    #endregion

    #region ARGB Actions

    private void AlphaValueChanged(object sender, ValueChangedEventArgs e) => Slidifiy(e.NewValue, aLabel, 255, "F2", "X2");
    private void RedValueChanged(object sender, ValueChangedEventArgs e) => Slidifiy(e.NewValue, rLabel);
    private void GreenValueChanged(object sender, ValueChangedEventArgs e) => Slidifiy(e.NewValue, gLabel);
    private void BlueValueChanged(object sender, ValueChangedEventArgs e) => Slidifiy(e.NewValue, bLabel);

    private void SwitchToogled(object sender, ToggledEventArgs e)
    {
        aLabel.Text = FormatValue(aSlider.Value, "F2", "X2", defaultModeSwitch.IsToggled, 255);
        rLabel.Text = FormatValue(rSlider.Value, "F0", "X2", defaultModeSwitch.IsToggled);
        gLabel.Text = FormatValue(gSlider.Value, "F0", "X2", defaultModeSwitch.IsToggled);
        bLabel.Text = FormatValue(bSlider.Value, "F0", "X2", defaultModeSwitch.IsToggled);
    }
    #endregion

    #region Supprot Functions

    private void Slidifiy(double value, Label label, double multiplayer = 1, string defaultFormat = "F0", string hexFormat = "X2")
    {
        label.Text = FormatValue(value, defaultFormat, hexFormat, defaultModeSwitch.IsToggled, multiplayer);
        NewColorHex = CreateColorHex();
        colorHexLabel.TextColor = ColorHexContrast();
    }

    private string FormatValue(double value, string defaultFormat, string hexFormat, bool isDefaultMode, double multiplayer = 1)
    {
        if (isDefaultMode)
            return value.ToString(defaultFormat);

        return GetHex(value, hexFormat, multiplayer);
    }

    private string GetHex(double value, string hexFormat, double multiplayer = 1) => ((int)(value*multiplayer)).ToString(hexFormat);

    private string CreateColorHex()
    {
        return string.Format("{0}{1}{2}{3}", GetHex(aSlider.Value, "X2", 255),
                                             GetHex(rSlider.Value, "X2"),
                                             GetHex(gSlider.Value, "X2"),
                                             GetHex(bSlider.Value, "X2"));
    }

    private Color ColorHexContrast()
    {
        if (aSlider.Value <= 0.31)
            return Color.FromArgb("1F2432");

        var rate = 0.2126 * rSlider.Value + 0.7152 * gSlider.Value + 0.0722 *  bSlider.Value;
        return rate < 128 ? Color.FromArgb("E7E9EF") : Color.FromArgb("1F2432");
    }
    #endregion
}
