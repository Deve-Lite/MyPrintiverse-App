using System.Globalization;
using System.Windows.Input;

namespace MyPrintiverse.FilamentsModule.FilamentTemplates.ValueIndicators;

public partial class RangeValueIndicator : ContentView
{
    #region Indicator Tapped

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(RangeValueIndicator), null);
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
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

        if (bindableEntry.DisplayValue == null)
            return;

        // in range
        // first in second out
        // first out second out 

        try
        {
            var values = bindableEntry.DisplayValue.Split('-');
            double minValue = double.Parse(values[0].Replace(',', '.'), CultureInfo.InvariantCulture);
            double maxValue = double.Parse(values[1].Replace(',', '.'), CultureInfo.InvariantCulture);
            double topValue = double.Parse(bindableEntry.TopValue.Replace(',', '.'), CultureInfo.InvariantCulture);

            double margin = 0;
            double height = 0;

            if (maxValue < topValue)
            {
                margin = 100 - (maxValue/topValue)*100;
                height = Math.Max(8, ((maxValue - minValue)/topValue)*100);

                if (margin+ height > 100)
                    margin = 100 - height;
            }
            else if (minValue < topValue)
            {
                margin = 0;
                height = Math.Max(8, ((maxValue - minValue)/topValue)*100);
            }
            else
            {
                margin = 0;
                height = 8;
            }



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