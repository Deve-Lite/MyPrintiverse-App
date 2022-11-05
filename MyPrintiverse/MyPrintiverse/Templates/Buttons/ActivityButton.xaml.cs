

using System.Windows.Input;

namespace MyPrintiverse.Templates.Buttons;

public partial class ActivityButton : ContentView
{
    #region Button

    public static readonly BindableProperty ButtonStyleProperty = BindableProperty.Create(nameof(ButtonStyle), typeof(Style), typeof(ActivityButton), null);
    public Style ButtonStyle
    {
        get => (Style)GetValue(ButtonStyleProperty);
        set => SetValue(ButtonStyleProperty, value);
    }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ActivityButton), null);
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly BindableProperty IsButtonEnabledProperty = BindableProperty.Create(nameof(IsButtonEnabled), typeof(bool), typeof(ActivityButton), false);
    public bool IsButtonEnabled
    {
        get => (bool)GetValue(IsButtonEnabledProperty);
        set => SetValue(IsButtonEnabledProperty, value);
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

    #region Label

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