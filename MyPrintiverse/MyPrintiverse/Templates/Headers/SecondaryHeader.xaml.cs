using System.Windows.Input;

namespace MyPrintiverse.Templates.Headers;

public partial class SecondaryHeader : ContentView
{
    #region Title

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(SecondaryHeader), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region Image Button

    public static readonly BindableProperty ImageCommandProperty = BindableProperty.Create(nameof(ImageCommand), typeof(ICommand), typeof(SecondaryHeader), null);
    public ICommand ImageCommand
    {
        get => (ICommand)GetValue(ImageCommandProperty);
        set => SetValue(ImageCommandProperty, value);
    }

    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(SecondaryHeader), "spool.png");
    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public static readonly BindableProperty ImageSizeProperty = BindableProperty.Create(nameof(ImageSize), typeof(string), typeof(SecondaryHeader), "32");
    public string ImageSize
    {
        get => (string)GetValue(ImageSizeProperty);
        set => SetValue(ImageSizeProperty, value);
    }

    #endregion

    public SecondaryHeader()
	{
		InitializeComponent();
	}
}