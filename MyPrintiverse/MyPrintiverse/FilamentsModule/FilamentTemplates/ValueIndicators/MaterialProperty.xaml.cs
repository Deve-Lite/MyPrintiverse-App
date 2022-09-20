using System.Windows.Input;

namespace MyPrintiverse.FilamentsModule.FilamentTemplates.ValueIndicators;

public partial class MaterialProperty : ContentView
{
    #region Display
    public string Source { get; set; }

    public static readonly BindableProperty ClickedCommandProperty = BindableProperty.Create(nameof(ClickedCommand), typeof(ICommand), typeof(MaterialProperty), null);
    public ICommand ClickedCommand
    {
        get => (ICommand)GetValue(ClickedCommandProperty);
        set => SetValue(ClickedCommandProperty, value);
    }

    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(MaterialProperty), true);
    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    #endregion

    #region Image

    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(MaterialProperty), "");
    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public static readonly BindableProperty InvalidImageSourceProperty = BindableProperty.Create(nameof(InvalidImageSource), typeof(string), typeof(MaterialProperty), "");
    public string InvalidImageSource
    {
        get => (string)GetValue(InvalidImageSourceProperty);
        set => SetValue(InvalidImageSourceProperty, value);
    }

    #endregion

    #region Title

    public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle), typeof(Style), typeof(MaterialProperty), null);
    public Style TitleStyle
    {
        get => (Style)GetValue(TitleStyleProperty);
        set => SetValue(TitleStyleProperty, value);
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(MaterialProperty), "");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region Frame

    public static readonly BindableProperty FrameStyleProperty = BindableProperty.Create(nameof(FrameStyle), typeof(Style), typeof(MaterialProperty), null);
    public Style FrameStyle
    {
        get => (Style)GetValue(FrameStyleProperty);
        set => SetValue(FrameStyleProperty, value);
    }

    #endregion

    public MaterialProperty()
	{
		InitializeComponent();
        if (IsValid)
            Source = ImageSource;    
        else
            Source = InvalidImageSource;
	}
}