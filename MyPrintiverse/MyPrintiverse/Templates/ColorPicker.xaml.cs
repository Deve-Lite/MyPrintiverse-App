using System.Globalization;

namespace MyPrintiverse.Templates;

public partial class ColorPicker : ContentView
{
    #region Switch

    public static readonly BindableProperty SliderModeProperty = BindableProperty.Create(nameof(SliderMode), typeof(bool), typeof(ColorPicker), true);
    public bool SliderMode
    {
        get => (bool)GetValue(SliderModeProperty);
        set => SetValue(SliderModeProperty, value);
    }

    #endregion 

    #region Hex

    public static readonly BindableProperty ColorHexProperty = BindableProperty.Create(nameof(ColorHex), typeof(string), typeof(ColorPicker), "", propertyChanged: OnHexChanged);
    public string ColorHex
    {
        get => (string)GetValue(ColorHexProperty);
        set => SetValue(ColorHexProperty, value);
    }

    private static void OnHexChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableColorPicker = (ColorPicker)bindable;
        /*
        //if (bindableColorPicker.SliderMode)
            //return;

        string color = bindableColorPicker.ColorHex;
        if (color.Length == 0)
            return;

        try
        {
            if (color.Length % 3 == 0)
            {
                bindableColorPicker.A = 1;

                if (color.Length == 3)
                {
                    bindableColorPicker.R = Int32.Parse(color.Substring(0, 1), NumberStyles.HexNumber);
                    bindableColorPicker.G = Int32.Parse(color.Substring(1, 1), NumberStyles.HexNumber);
                    bindableColorPicker.B = Int32.Parse(color.Substring(2, 1), NumberStyles.HexNumber);
                }
                else
                {
                    bindableColorPicker.R = Int32.Parse(color.Substring(0, 2), NumberStyles.HexNumber);
                    bindableColorPicker.G = Int32.Parse(color.Substring(2, 2), NumberStyles.HexNumber);
                    bindableColorPicker.B = Int32.Parse(color.Substring(4, 2), NumberStyles.HexNumber);
                }
            }


            if (color.Length % 4 == 0)
            {
                if (color.Length == 3)
                {
                    bindableColorPicker.A = double.Parse(color.Substring(0, 1), NumberStyles.HexNumber);
                    bindableColorPicker.R = Int32.Parse(color.Substring(1, 1), NumberStyles.HexNumber);
                    bindableColorPicker.G = Int32.Parse(color.Substring(2, 1), NumberStyles.HexNumber);
                    bindableColorPicker.B = Int32.Parse(color.Substring(3, 1), NumberStyles.HexNumber);
                }
                else
                {
                    bindableColorPicker.A = double.Parse(color.Substring(0, 2), NumberStyles.HexNumber);
                    bindableColorPicker.R = Int32.Parse(color.Substring(2, 2), NumberStyles.HexNumber);
                    bindableColorPicker.G = Int32.Parse(color.Substring(4, 2), NumberStyles.HexNumber);
                    bindableColorPicker.B = Int32.Parse(color.Substring(6, 2), NumberStyles.HexNumber);
                }
            }
        }
        catch
        {
            
        }
        */

    }

    #endregion

    #region Sliders

    public static readonly BindableProperty RProperty = BindableProperty.Create(nameof(R), typeof(double), typeof(ColorPicker), 0, propertyChanged: OnRGBChanged);
    public double R
    {
        get => (double)GetValue(RProperty);
        set => SetValue(RProperty, value);
    }

    public static readonly BindableProperty GProperty = BindableProperty.Create(nameof(G), typeof(double), typeof(ColorPicker), 0, propertyChanged: OnRGBChanged);
    public double G
    {
        get => (double)GetValue(GProperty);
        set => SetValue(GProperty, value);
    }

    public static readonly BindableProperty BProperty = BindableProperty.Create(nameof(B), typeof(double), typeof(ColorPicker), 0, propertyChanged: OnRGBChanged);
    public double B
    {
        get => (double)GetValue(BProperty);
        set => SetValue(BProperty, value);
    }

    public static readonly BindableProperty AProperty = BindableProperty.Create(nameof(A), typeof(double), typeof(ColorPicker), 0, propertyChanged: OnRGBChanged);
    public double A
    {
        get => (double)GetValue(AProperty);
        set => SetValue(AProperty, value);
    }

    private static void OnRGBChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableColorPicker = (ColorPicker)bindable;

        bindableColorPicker.ColorHex = ((int)(bindableColorPicker.A * 255)).ToString("X2") +
                                       ((int)bindableColorPicker.R).ToString("X2") +
                                       ((int)bindableColorPicker.G).ToString("X2") +
                                       ((int)bindableColorPicker.B).ToString("X2");
    }

    #endregion

    public ColorPicker()
    {
        InitializeComponent();


    }
}
