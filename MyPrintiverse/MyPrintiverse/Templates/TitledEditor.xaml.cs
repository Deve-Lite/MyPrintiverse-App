using System.Windows.Input;

namespace MyPrintiverse.Templates;

public partial class TitledEditor : ContentView
{
    #region Entry Grid
    // sets height of entry grid (sometimes weird height problem)

    public static readonly BindableProperty SupportHeightProperty = BindableProperty.Create(nameof(SupportHeight), typeof(int), typeof(TitledEditor), 50);
    public int SupportHeight
    {
        get => (int)GetValue(SupportHeightProperty);
        set => SetValue(SupportHeightProperty, value);
    }

    #endregion

    #region Validation

    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(TitledEditor), false, BindingMode.TwoWay, propertyChanged: OnIsValidChanged);
    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }
    private static void OnIsValidChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableEntry = (TitledEditor)bindable;

        if (bindableEntry.IsValid)
            bindableEntry.Border.Stroke = bindableEntry.ValidStrokeBrush;
        else
            bindableEntry.Border.Stroke = bindableEntry.InvalidStrokeBrush;
    }

    public static readonly BindableProperty ValidationCommandProperty = BindableProperty.Create(nameof(ValidationCommand), typeof(ICommand), typeof(TitledEditor), null);
    public ICommand ValidationCommand
    {
        get => (ICommand)GetValue(ValidationCommandProperty);
        set => SetValue(ValidationCommandProperty, value);
    }

    #endregion

    #region Title
    public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle), typeof(Style), typeof(TitledEditor), new Style(typeof(Label)) { });
    public Style TitleStyle
    {
        get => (Style)GetValue(TitleStyleProperty);
        set => SetValue(TitleStyleProperty, value);
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(TitledEditor), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region ErrorMessage
    public static readonly BindableProperty ErrorMessageStyleProperty = BindableProperty.Create(nameof(ErrorMessageStyle), typeof(Style), typeof(TitledEditor), new Style(targetType: typeof(Label)) { }, propertyChanged: SetHeight);
    public Style ErrorMessageStyle
    {
        get => (Style)GetValue(ErrorMessageStyleProperty);
        set => SetValue(ErrorMessageStyleProperty, value);
    }

    public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(TitledEditor), "");
    public string ErrorMessage
    {
        get => (string)GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }

    public static readonly BindableProperty ErrorMessageLinesProperty = BindableProperty.Create(nameof(ErrorMessageLines), typeof(int), typeof(TitledEditor), 1);
    public int ErrorMessageLines
    {
        get => (int)GetValue(ErrorMessageLinesProperty);
        set => SetValue(ErrorMessageLinesProperty, value);
    }

    private static void SetHeight(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableEntry = (TitledEditor)bindable;

        bindableEntry.errorMessage.HeightRequest = bindableEntry.ErrorMessageLines * ((int)bindableEntry.errorMessage.FontSize + 2);
    }

    #endregion

    #region Editor

    public static readonly BindableProperty EditorStyleProperty = BindableProperty.Create(nameof(EditorStyle), typeof(Style), typeof(TitledEditor), new Style(typeof(Entry)) { });
    public Style EditorStyle
    {
        get => (Style)GetValue(EditorStyleProperty);
        set => SetValue(EditorStyleProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TitledEditor), "", BindingMode.TwoWay);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(TitledEditor), "Aa...");
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    #endregion

    #region Border

    public static readonly BindableProperty BorderStyleProperty = BindableProperty.Create(nameof(BorderStyle), typeof(Style), typeof(TitledEditor), null, propertyChanged: OnBorderStyleChanged);
    public Style BorderStyle
    {
        get => (Style)GetValue(BorderStyleProperty);
        set => SetValue(BorderStyleProperty, value);
    }

    private static void OnBorderStyleChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableEntry = (TitledEditor)bindable;

        if (bindableEntry.Border.Stroke != null)
            bindableEntry.ValidStrokeBrush = (bindableEntry.Border.Stroke as SolidColorBrush).Color;

    }

    public Color ValidStrokeBrush { get; set; }

    public static readonly BindableProperty InvalidStrokeBrushProperty = BindableProperty.Create(nameof(InvalidStrokeBrush), typeof(Color), typeof(TitledEditor), Color.FromRgb(212, 33, 33));
    public Color InvalidStrokeBrush
    {
        get => (Color)GetValue(InvalidStrokeBrushProperty);
        set => SetValue(InvalidStrokeBrushProperty, value);
    }

    #endregion
    public TitledEditor()
	{
		InitializeComponent();
	}
}