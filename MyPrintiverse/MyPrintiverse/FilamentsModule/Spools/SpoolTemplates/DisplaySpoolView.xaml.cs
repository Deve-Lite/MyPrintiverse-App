using CommunityToolkit.Maui.Views;
using MyPrintiverse.Templates.Popups;
using System.Globalization;

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

    public static readonly BindableProperty TypeIdProperty = BindableProperty.Create(nameof(TypeId), typeof(string), typeof(DisplaySpoolView), "");
    public string TypeId
    {
        get => (string)GetValue(TypeIdProperty);
        set => SetValue(TypeIdProperty, value);
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

    public static readonly BindableProperty AvaliableWeightProperty = BindableProperty.Create(nameof(AvaliableWeight), typeof(string), typeof(DisplaySpoolView), "", propertyChanged: SpoolChanged);
    public string AvaliableWeight
    {
        get => (string)GetValue(AvaliableWeightProperty);
        set => SetValue(AvaliableWeightProperty, value);
    }

    public static readonly BindableProperty StandardWeightProperty = BindableProperty.Create(nameof(StandardWeight), typeof(string), typeof(DisplaySpoolView), "", propertyChanged: SpoolChanged);
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

    public static readonly BindableProperty IsFinishedProperty = BindableProperty.Create(nameof(IsFinished), typeof(bool), typeof(DisplaySpoolView), false, propertyChanged: SpoolChanged);
    public bool IsFinished
    {
        get => (bool)GetValue(IsFinishedProperty);
        set => SetValue(IsFinishedProperty, value);
    }

    public static readonly BindableProperty IsOnSpoolProperty = BindableProperty.Create(nameof(IsOnSpool), typeof(bool), typeof(DisplaySpoolView), false, propertyChanged:SpoolChanged);
    public bool IsOnSpool
    {
        get => (bool)GetValue(IsOnSpoolProperty);
        set => SetValue(IsOnSpoolProperty, value);
    }

    private static void SpoolChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var spoolView = (DisplaySpoolView)bindable;

        if (string.IsNullOrEmpty(spoolView.AvaliableWeight) || string.IsNullOrEmpty(spoolView.StandardWeight))
            return;

        double avaliableWeight = double.Parse(spoolView.AvaliableWeight.Replace(',', '.'), CultureInfo.InvariantCulture);
        double standardWeight = double.Parse(spoolView.StandardWeight.Replace(',', '.'), CultureInfo.InvariantCulture);

        if (!spoolView.IsOnSpool)
            spoolView.spoolImage.Source = "rope.png";
        else if (spoolView.IsFinished)
            spoolView.spoolImage.Source = "emptyspool.png";
        else if (avaliableWeight >= 0.8 * standardWeight)
            spoolView.spoolImage.Source = "fullspool.png";
        else if (avaliableWeight >= 0.2 * standardWeight)
            spoolView.spoolImage.Source = "mediumspool.png";
        else
            spoolView.spoolImage.Source = "smallspool.png";
    }

    #endregion

    public DisplaySpoolView()
	{
		InitializeComponent();
    }

    private void NoteClicked(object sender, EventArgs e)
    {
        Shell.Current.ShowPopup(new DescriptionPopup(Description));
    }
}