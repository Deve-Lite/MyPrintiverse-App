namespace MyPrintiverse.FilamentsModule.Types.FilamentTypeTemplates;

public partial class FilamentTypeDisplay : ContentView
{
    #region TextFields
    public static readonly BindableProperty ShortNameProperty = BindableProperty.Create(nameof(ShortName), typeof(string), typeof(FilamentTypeDisplay), "");
    public string ShortName
    {
        get => (string)GetValue(ShortNameProperty);
        set => SetValue(ShortNameProperty, value);
    }

    public static readonly BindableProperty FullNameProperty = BindableProperty.Create(nameof(FullName), typeof(string), typeof(FilamentTypeDisplay), "");
    public string FullName
    {
        get => (string)GetValue(FullNameProperty);
        set => SetValue(FullNameProperty, value);
    }

    public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(FilamentTypeDisplay), "");
    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public static readonly BindableProperty DensityProperty = BindableProperty.Create(nameof(Density), typeof(string), typeof(FilamentTypeDisplay), "");
    public string Density
    {
        get => (string)GetValue(DensityProperty);
        set => SetValue(DensityProperty, value);
    }

    public static readonly BindableProperty MaxServiceTempearatureProperty = BindableProperty.Create(nameof(MaxServiceTempearature), typeof(string), typeof(FilamentTypeDisplay), "");
    public string MaxServiceTempearature
    {
        get => (string)GetValue(MaxServiceTempearatureProperty);
        set => SetValue(MaxServiceTempearatureProperty, value);
    }


    #endregion

    #region Prtint settings

    public static readonly BindableProperty NozzleTemperatureRangeProperty = BindableProperty.Create(nameof(NozzleTemperatureRange), typeof(string), typeof(FilamentTypeDisplay), "");
    public string NozzleTemperatureRange
    {
        get => (string)GetValue(NozzleTemperatureRangeProperty);
        set => SetValue(NozzleTemperatureRangeProperty, value);
    }

    public static readonly BindableProperty BedTemperatureRangeProperty = BindableProperty.Create(nameof(BedTemperatureRange), typeof(string), typeof(FilamentTypeDisplay), "");
    public string BedTemperatureRange
    {
        get => (string)GetValue(BedTemperatureRangeProperty);
        set => SetValue(BedTemperatureRangeProperty, value);
    }

    public static readonly BindableProperty CoolingRangeProperty = BindableProperty.Create(nameof(CoolingRange), typeof(string), typeof(FilamentTypeDisplay), "");
    public string CoolingRange
    {
        get => (string)GetValue(CoolingRangeProperty);
        set => SetValue(CoolingRangeProperty, value);
    }

    #endregion

    #region Properties

    public static readonly BindableProperty IsFoodFriendlyProperty = BindableProperty.Create(nameof(IsFoodFriendly), typeof(bool), typeof(FilamentTypeDisplay), false);
    public string IsFoodFriendly
    {
        get => (string)GetValue(IsFoodFriendlyProperty);
        set => SetValue(IsFoodFriendlyProperty, value);
    }

    public static readonly BindableProperty IsFlexibleProperty = BindableProperty.Create(nameof(IsFlexible), typeof(bool), typeof(FilamentTypeDisplay), false);
    public string IsFlexible
    {
        get => (string)GetValue(IsFlexibleProperty);
        set => SetValue(IsFlexibleProperty, value);
    }

    public static readonly BindableProperty IsBioProperty = BindableProperty.Create(nameof(IsBio), typeof(bool), typeof(FilamentTypeDisplay), false);
    public string IsBio
    {
        get => (string)GetValue(IsBioProperty);
        set => SetValue(IsBioProperty, value);
    }

    public static readonly BindableProperty IsUVResistantProperty = BindableProperty.Create(nameof(IsUVResistant), typeof(bool), typeof(FilamentTypeDisplay), false);
    public string IsUVResistant
    {
        get => (string)GetValue(IsUVResistantProperty);
        set => SetValue(IsUVResistantProperty, value);
    }

    public static readonly BindableProperty IsHeatedBedRequiredProperty = BindableProperty.Create(nameof(IsHeatedBedRequired), typeof(bool), typeof(FilamentTypeDisplay), false);
    public string IsHeatedBedRequired
    {
        get => (string)GetValue(IsHeatedBedRequiredProperty);
        set => SetValue(IsHeatedBedRequiredProperty, value);
    }

    #endregion

    #region Others

    public static readonly BindableProperty EditedAtProperty = BindableProperty.Create(nameof(EditedAt), typeof(string), typeof(FilamentTypeDisplay), "");
    public string EditedAt
    {
        get => (string)GetValue(EditedAtProperty);
        set => SetValue(EditedAtProperty, value);
    }

    #endregion

    public FilamentTypeDisplay()
	{
		InitializeComponent();
	}
}