

namespace MyPrintiverse.Templates;

public partial class ActivityButton : ContentView
{
    #region Button

    public static readonly BindableProperty ButtonStyleProperty = BindableProperty.Create(nameof(ButtonStyle), typeof(Style), typeof(ActivityButton), null);
    public Style ButtonStyle
    {
        get => (Style)GetValue(ButtonStyleProperty);
        set => SetValue(ButtonStyleProperty, value);
    }

    public static readonly BindableProperty ButtonCommandProperty = BindableProperty.Create(nameof(ButtonCommand), typeof(ICommand), typeof(ActivityButton), null);
    public ICommand ButtonCommand
    {
        get => (ICommand)GetValue(ButtonCommandProperty);
        set => SetValue(ButtonCommandProperty, value);
    }

    public static readonly BindableProperty ButtonIsEnabledProperty = BindableProperty.Create(nameof(ButtonIsEnabled), typeof(bool), typeof(ActivityButton), false);
    public bool ButtonIsEnabled
    {
        get => (bool)GetValue(IsEnabledProperty);
        set => SetValue(IsEnabledProperty, value);
    }

    #endregion

    #region ActivityIndicator

    public static readonly BindableProperty ActivityIndicatorStyleProperty = BindableProperty.Create(nameof(ActivityIndicatorStyle), typeof(Style), typeof(ActivityButton), null);
    public Style ActivityIndicatorStyle
    {
        get => (Style)GetValue(ActivityIndicatorStyleProperty);
        set => SetValue(ActivityIndicatorStyleProperty, value);
    }

    public static readonly BindableProperty IsRunningProperty = BindableProperty.Create(nameof(IsRunning), typeof(bool), typeof(ActivityButton), false);
    public bool IsRunning
    {
        get => (bool)GetValue(IsRunningProperty);
        set => SetValue(IsRunningProperty, value);
    }

    #endregion

    #region Text

    public static readonly BindableProperty TextStyleProperty = BindableProperty.Create(nameof(TextStyle), typeof(Style), typeof(ActivityButton), null);
    public Style TextStyle
    {
        get => (Style)GetValue(TextStyleProperty);
        set => SetValue(TextStyleProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ActivityButton), "");
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #endregion

    public ActivityButton()
	{
        InitializeComponent();
    }
}