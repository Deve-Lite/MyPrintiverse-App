using System.Windows.Input;

namespace MyPrintiverse.Templates.Headers;

public partial class TertiaryHeader : ContentView
{
    #region Title

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(PrimaryHeader), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region First Action Data

    public static readonly BindableProperty FirstCommandProperty = BindableProperty.Create(nameof(FirstCommand), typeof(ICommand), typeof(PrimaryHeader), null);
    public ICommand FirstCommand
    {
        get => (ICommand)GetValue(FirstCommandProperty);
        set => SetValue(FirstCommandProperty, value);
    }

    public static readonly BindableProperty FirstSourceProperty = BindableProperty.Create(nameof(FirstSource), typeof(string), typeof(PrimaryHeader), "spool.png");
    public string FirstSource
    {
        get => (string)GetValue(FirstSourceProperty);
        set => SetValue(FirstSourceProperty, value);
    }

    #endregion

    #region Second Action Data

    public static readonly BindableProperty SecondCommandProperty = BindableProperty.Create(nameof(SecondCommand), typeof(ICommand), typeof(PrimaryHeader), null);
    public ICommand SecondCommand
    {
        get => (ICommand)GetValue(SecondCommandProperty);
        set => SetValue(SecondCommandProperty, value);
    }

    public static readonly BindableProperty SecondSourceProperty = BindableProperty.Create(nameof(SecondSource), typeof(string), typeof(PrimaryHeader), "spool.png");
    public string SecondSource
    {
        get => (string)GetValue(SecondSourceProperty);
        set => SetValue(SecondSourceProperty, value);
    }

    #endregion

    public TertiaryHeader()
	{
		InitializeComponent();
	}
}