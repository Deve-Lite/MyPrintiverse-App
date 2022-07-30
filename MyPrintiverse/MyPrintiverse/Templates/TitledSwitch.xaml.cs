
namespace MyPrintiverse.Templates;

public partial class TitledSwitch : ContentView
{

    #region Title
    public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle), typeof(Style), typeof(TitledSwitch), null);
    public Style TitleStyle
    {
        get => (Style)GetValue(TitleStyleProperty);
        set => SetValue(TitleStyleProperty, value);
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

    #region Frame
    public static readonly BindableProperty FrameStyleProperty = BindableProperty.Create(nameof(FrameStyle), typeof(Style), typeof(ValidatableEntry), null);
    public Style FrameStyle
    {
        get => (Style)GetValue(FrameStyleProperty);
        set => SetValue(FrameStyleProperty, value);
    }
    #endregion

    public TitledSwitch()
	{
		InitializeComponent();
	}
}