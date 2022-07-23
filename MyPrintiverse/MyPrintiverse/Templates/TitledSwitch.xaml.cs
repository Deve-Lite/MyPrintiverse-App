
namespace MyPrintiverse.Templates;

public partial class TitledSwitch : ContentView
{

    #region Label
    public static readonly BindableProperty LabelStyleProperty = BindableProperty.Create(nameof(LabelStyle), typeof(Style), typeof(TitledSwitch), null);
    public Style LabelStyle
    {
        get => (Style)GetValue(LabelStyleProperty);
        set => SetValue(LabelStyleProperty, value);
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(TitledSwitch), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    #endregion

    #region Switch
    public static readonly BindableProperty SwitchStyleProperty = BindableProperty.Create(nameof(SwitchStyle), typeof(Style), typeof(TitledSwitch), null);
    public Style SwitchStyle
    {
        get => (Style)GetValue(SwitchStyleProperty);
        set => SetValue(SwitchStyleProperty, value);
    }

    public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(TitledSwitch), false);
    public bool IsToggled
    {
        get => (bool)GetValue(IsToggledProperty);
        set => SetValue(IsToggledProperty, value);
    }

    #endregion

    public TitledSwitch()
	{
		InitializeComponent();
	}
}