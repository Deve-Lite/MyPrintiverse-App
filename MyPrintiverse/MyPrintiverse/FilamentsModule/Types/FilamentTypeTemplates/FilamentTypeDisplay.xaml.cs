using CommunityToolkit.Maui.Views;
using MyPrintiverse.Templates.Popups;

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
    public bool IsFoodFriendly
    {
        get => (bool)GetValue(IsFoodFriendlyProperty);
        set => SetValue(IsFoodFriendlyProperty, value);
    }

    public static readonly BindableProperty IsFlexibleProperty = BindableProperty.Create(nameof(IsFlexible), typeof(bool), typeof(FilamentTypeDisplay), false);
    public bool IsFlexible
    {
        get => (bool)GetValue(IsFlexibleProperty);
        set => SetValue(IsFlexibleProperty, value);
    }

    public static readonly BindableProperty IsBioProperty = BindableProperty.Create(nameof(IsBio), typeof(bool), typeof(FilamentTypeDisplay), false);
    public bool IsBio
    {
        get => (bool)GetValue(IsBioProperty);
        set => SetValue(IsBioProperty, value);
    }

    public static readonly BindableProperty IsUVResistantProperty = BindableProperty.Create(nameof(IsUVResistant), typeof(bool), typeof(FilamentTypeDisplay), false);
    public bool IsUVResistant
    {
        get => (bool)GetValue(IsUVResistantProperty);
        set => SetValue(IsUVResistantProperty, value);
    }

    public static readonly BindableProperty IsHeatedBedRequiredProperty = BindableProperty.Create(nameof(IsHeatedBedRequired), typeof(bool), typeof(FilamentTypeDisplay), false);
    public bool IsHeatedBedRequired
    {
        get => (bool)GetValue(IsHeatedBedRequiredProperty);
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

        NozzleTemperatureRangeIndicator.Command = new CommunityToolkit.Mvvm.Input.RelayCommand(() => {
            Shell.Current.ShowPopup(new DescriptionPopup("This indicator shows noozle temperature requirements. Printing with other values may cause problems and break 3d printer.", "Nozzle"));
        });
        CoolingRangeIndicator.Command = new CommunityToolkit.Mvvm.Input.RelayCommand(() => {
            Shell.Current.ShowPopup(new DescriptionPopup("This indicator shows cooling reqirements. Ofcourse this is not required, but using cooling well may give insane results.", "Cooling"));
        });
        BedTemperatureRangeIndicator.Command = new CommunityToolkit.Mvvm.Input.RelayCommand(() => {
            Shell.Current.ShowPopup(new DescriptionPopup("This indicator shows heated bed requirements. Using heated bed gives better print adhesion and also reduces chaces for print detachment from printing surface", "Heated Bed"));
        });

        FoodFriendlyIndicator.Command = new CommunityToolkit.Mvvm.Input.RelayCommand(() =>
        {
            Shell.Current.ShowPopup(new DescriptionPopup("This indicator shows if material could be used with food. " +
                "When marking this field you should consider if material conatinas any dangerous substances. " +
                "Remember that material can be friendly but material paint don't have to.", "Food Friendliness"));
        });
        BioIndicator.Command = new CommunityToolkit.Mvvm.Input.RelayCommand(() =>
        {
            Shell.Current.ShowPopup(new DescriptionPopup("This indicator shows if material is bio. " +
                "Remember that material could be bio but material paint don't have to be.", "Biodegradability"));
        });
        FlexibleIndicator.Command = new CommunityToolkit.Mvvm.Input.RelayCommand(() =>
        {
            Shell.Current.ShowPopup(new DescriptionPopup("This indicator shows if material is flexible.", "Flexibility"));
        });
        UVResistantIndicator.Command = new CommunityToolkit.Mvvm.Input.RelayCommand(() =>
        {
            Shell.Current.ShowPopup(new DescriptionPopup("This indicator shows if material is uv resistant.", "UV Resistance"));
        });
        HeatedBedRequiredIndicator.Command = new CommunityToolkit.Mvvm.Input.RelayCommand(() =>
        {
            Shell.Current.ShowPopup(new DescriptionPopup("This indicator shows if material requires heated bed for printing.", "Bed Heating"));
        });

    }

    private void NoteClicked(object sender, EventArgs e)
    {
        Shell.Current.ShowPopup(new DescriptionPopup(Description));
    }

    private void MeltingClicked(object sender, EventArgs e)
    {
        Shell.Current.ShowPopup(new DescriptionPopup("This value is representing temperature at which filament is softing and starts to change it's shapes.", "Softing Point"));
    }
}