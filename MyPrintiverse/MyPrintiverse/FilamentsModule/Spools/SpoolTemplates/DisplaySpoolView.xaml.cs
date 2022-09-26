using MyPrintiverse.FilamentsModule.FilamentTemplates.Others;

namespace MyPrintiverse.FilamentsModule.Spools.SpoolTemplates;

public partial class DisplaySpoolView : ContentView
{
    #region TextFields
    public static readonly BindableProperty BrandProperty = BindableProperty.Create(nameof(Brand), typeof(string), typeof(DisplaySpoolView), "");
    public string Brand
    {
        get => (string)GetValue(BrandProperty);
        set => SetValue(BrandProperty, value);
    }

    public static readonly BindableProperty TypeProperty = BindableProperty.Create(nameof(Type), typeof(string), typeof(DisplaySpoolView), "");
    public string Type
    {
        get => (string)GetValue(TypeProperty);
        set => SetValue(TypeProperty, value);
    }

    public static readonly BindableProperty ColorNameProperty = BindableProperty.Create(nameof(ColorName), typeof(string), typeof(DisplaySpoolView), "");
    public string ColorName
    {
        get => (string)GetValue(ColorNameProperty);
        set => SetValue(ColorNameProperty, value);
    }

    public static readonly BindableProperty DiameterProperty = BindableProperty.Create(nameof(Diameter), typeof(string), typeof(DisplaySpoolView), "");
    public string Diameter
    {
        get => (string)GetValue(DiameterProperty);
        set => SetValue(DiameterProperty, value);
    }

    public static readonly BindableProperty AvaliableWeightProperty = BindableProperty.Create(nameof(AvaliableWeight), typeof(string), typeof(DisplaySpoolView), "");
    public string AvaliableWeight
    {
        get => (string)GetValue(AvaliableWeightProperty);
        set => SetValue(AvaliableWeightProperty, value);
    }

    public static readonly BindableProperty StandardWeightProperty = BindableProperty.Create(nameof(StandardWeight), typeof(string), typeof(DisplaySpoolView), "");
    public string StandardWeight
    {
        get => (string)GetValue(StandardWeightProperty);
        set => SetValue(StandardWeightProperty, value);
    }

    public static readonly BindableProperty CostProperty = BindableProperty.Create(nameof(Cost), typeof(string), typeof(DisplaySpoolView), "");
    public string Cost
    {
        get => (string)GetValue(CostProperty);
        set => SetValue(CostProperty, value);
    }

    public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(DisplaySpoolView), "");
    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public static readonly BindableProperty IsDescriptionVisibleProperty = BindableProperty.Create(nameof(IsDescriptionVisible), typeof(bool), typeof(DisplaySpoolView), true);
    public bool IsDescriptionVisible
    {
        get => (bool)GetValue(IsDescriptionVisibleProperty);
        set => SetValue(IsDescriptionVisibleProperty, value);
    }

    public static readonly BindableProperty EditedAtProperty = BindableProperty.Create(nameof(EditedAt), typeof(string), typeof(DisplaySpoolView), "");
    public string EditedAt
    {
        get => (string)GetValue(EditedAtProperty);
        set => SetValue(EditedAtProperty, value);
    }

    public static readonly BindableProperty CurrencyProperty = BindableProperty.Create(nameof(Currency), typeof(string), typeof(DisplaySpoolView), "");
    public string Currency
    {
        get => (string)GetValue(CurrencyProperty);
        set => SetValue(CurrencyProperty, value);
    }

    #endregion

    public DisplaySpoolView()
	{
		InitializeComponent();
	}
}