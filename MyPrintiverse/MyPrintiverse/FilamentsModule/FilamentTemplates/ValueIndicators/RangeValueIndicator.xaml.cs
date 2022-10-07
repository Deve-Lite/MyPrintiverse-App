using System.Globalization;
using System.Windows.Input;

namespace MyPrintiverse.FilamentsModule.FilamentTemplates.ValueIndicators;

public partial class RangeValueIndicator : ContentView
{
    #region Indicator Tapped

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(RangeValueIndicator), null);
    public string Command
    {
        get => (string)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    #endregion

    #region Image

    public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(RangeValueIndicator), "spool.png");
    public string Source
    {
        get => (string)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    #endregion

    #region Values

    public static readonly BindableProperty DisplayValueProperty = BindableProperty.Create(nameof(DisplayValue), typeof(string), typeof(RangeValueIndicator), "", propertyChanged: OnValuesChanged);
    public string DisplayValue
    {
        get => (string)GetValue(DisplayValueProperty);
        set => SetValue(DisplayValueProperty, value);
    }

    public static readonly BindableProperty TopValueProperty = BindableProperty.Create(nameof(TopValue), typeof(string), typeof(RangeValueIndicator), "");
    public string TopValue
    {
        get => (string)GetValue(TopValueProperty);
        set => SetValue(TopValueProperty, value);
    }

    public static readonly BindableProperty EntityProperty = BindableProperty.Create(nameof(Entity), typeof(string), typeof(RangeValueIndicator), "", propertyChanged: OnValuesChanged);
    public string Entity
    {
        get => (string)GetValue(EntityProperty);
        set => SetValue(EntityProperty, value);
    }

    private static void OnValuesChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableEntry = (RangeValueIndicator)bindable;

        try
        {
            var values = bindableEntry.DisplayValue.Split('-');

            double minValue = double.Parse(values[0].Replace(',', '.'), CultureInfo.InvariantCulture);
            double maxValue = double.Parse(values[1].Replace(',', '.'), CultureInfo.InvariantCulture);
            double topValue = double.Parse(bindableEntry.TopValue.Replace(',', '.'), CultureInfo.InvariantCulture);
            double margin = Math.Min(100 - (maxValue / topValue) * 100, 97);
            double height = 0;
            if (margin == 97)
                height = 3;
            else
                height = Math.Max( ((maxValue - minValue) * 100) / topValue, 3);

            bindableEntry.indicator.Margin = new Thickness(0, margin, 0, 0);
            bindableEntry.indicator.HeightRequest = height;
        }
        catch 
        {
        }
    }

    #endregion

    public RangeValueIndicator()
	{
		InitializeComponent();
    }
}