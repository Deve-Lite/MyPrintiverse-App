using System.Windows.Input;

namespace MyPrintiverse.Templates.Headers;

public partial class TertiaryHeader : ContentView
{
    #region Title

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(TertiaryHeader), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region First ImageButton

    public static readonly BindableProperty FirstImageCommandProperty = BindableProperty.Create(nameof(FirstImageCommand), typeof(ICommand), typeof(TertiaryHeader), null);
    public ICommand FirstImageCommand
    {
        get => (ICommand)GetValue(FirstImageCommandProperty);
        set => SetValue(FirstImageCommandProperty, value);
    }

    public static readonly BindableProperty FirstImageSourceProperty = BindableProperty.Create(nameof(FirstImageSource), typeof(string), typeof(TertiaryHeader), "spool.png");
    public string FirstImageSource
    {
        get => (string)GetValue(FirstImageSourceProperty);
        set => SetValue(FirstImageSourceProperty, value);
    }

    public static readonly BindableProperty FirstImageSizeProperty = BindableProperty.Create(nameof(FirstImageSize), typeof(string), typeof(TertiaryHeader), "32");
    public string FirstImageSize
    {
        get => (string)GetValue(FirstImageSizeProperty);
        set => SetValue(FirstImageSizeProperty, value);
    }

    #endregion

    #region Second ImageButton

    public static readonly BindableProperty SecondImageCommandProperty = BindableProperty.Create(nameof(SecondImageCommand), typeof(ICommand), typeof(TertiaryHeader), null);
    public ICommand SecondImageCommand
    {
        get => (ICommand)GetValue(SecondImageCommandProperty);
        set => SetValue(SecondImageCommandProperty, value);
    }

    public static readonly BindableProperty SecondImageSourceProperty = BindableProperty.Create(nameof(SecondImageSource), typeof(string), typeof(TertiaryHeader), "spool.png");
    public string SecondImageSource
    {
        get => (string)GetValue(SecondImageSourceProperty);
        set => SetValue(SecondImageSourceProperty, value);
    }

    public static readonly BindableProperty SecondImageSizeProperty = BindableProperty.Create(nameof(SecondImageSize), typeof(string), typeof(TertiaryHeader), "32");
    public string SecondImageSize
    {
        get => (string)GetValue(SecondImageSizeProperty);
        set => SetValue(SecondImageSizeProperty, value);
    }

    #endregion

    public TertiaryHeader()
	{
		InitializeComponent();
	}
}