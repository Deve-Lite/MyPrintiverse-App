using System.Windows.Input;

namespace MyPrintiverse.FilamentsModule.FilamentTemplates.ValueIndicators;

public partial class MaterialProperty : ContentView
{
    #region Display

    public static readonly BindableProperty ClickedCommandProperty = BindableProperty.Create(nameof(ClickedCommand), typeof(ICommand), typeof(MaterialProperty), null);
    public ICommand ClickedCommand
    {
        get => (ICommand)GetValue(ClickedCommandProperty);
        set => SetValue(ClickedCommandProperty, value);
    }

    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(MaterialProperty), true, propertyChanged:IsValidChanged);
    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    private static void IsValidChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var materialFrame = (MaterialProperty)bindable;

        if (materialFrame.IsValid)
            materialFrame.image.Source = materialFrame.ImageSource;
        else
            materialFrame.image.Source = materialFrame.InvalidImageSource;
    }

    #endregion

    #region Image

    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(MaterialProperty), "star.png");
    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public static readonly BindableProperty InvalidImageSourceProperty = BindableProperty.Create(nameof(InvalidImageSource), typeof(string), typeof(MaterialProperty), "emptystar.png");
    public string InvalidImageSource
    {
        get => (string)GetValue(InvalidImageSourceProperty);
        set => SetValue(InvalidImageSourceProperty, value);
    }

    #endregion

    #region Title

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(MaterialProperty), "");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    public MaterialProperty()
	{
		InitializeComponent();
        if (IsValid)
            image.Source = ImageSource;    
        else
            image.Source = InvalidImageSource;
	}
}