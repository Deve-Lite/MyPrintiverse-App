namespace MyPrintiverse.Templates;

public partial class ValidatableEntry : ContentView, INotifyPropertyChanged
{
    #region Validation

    private static Color DefaultColor;

    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(ValidatableEntry), false, BindingMode.TwoWay, propertyChanged: OnIsValidChanged);
    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    private static void OnIsValidChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableEntry = (ValidatableEntry)bindable;

        if (DefaultColor == null)
            DefaultColor = bindableEntry.Frame.BorderColor;

        if (bindableEntry.IsValid)
            bindableEntry.Frame.BorderColor = DefaultColor;
        else
            bindableEntry.Frame.BorderColor = Color.FromRgb(212, 33, 33);
    }

    public static readonly BindableProperty ValidationCommandProperty = BindableProperty.Create(nameof(ValidationCommand), typeof(ICommand), typeof(ValidatableEntry), null);
    public ICommand ValidationCommand
    {
        get => (ICommand)GetValue(ValidationCommandProperty);
        set => SetValue(ValidationCommandProperty, value);
    }

    #endregion

    #region Title
    public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle), typeof(Style), typeof(ValidatableEntry), new Style(typeof(Label)) { });
    public Style TitleStyle
    {
        get => (Style)GetValue(TitleStyleProperty);
        set => SetValue(TitleStyleProperty, value);
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ValidatableEntry), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region ErrorMessage
    public static readonly BindableProperty ErrorMessageStyleProperty = BindableProperty.Create(nameof(ErrorMessageStyle), typeof(Style), typeof(ValidatableEntry), new Style(typeof(Label)) { });
    public Style ErrorMessageStyle
    {
        get => (Style)GetValue(ErrorMessageStyleProperty);
        set => SetValue(ErrorMessageStyleProperty, value);
    }

    public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(ValidatableEntry), "");
    public string ErrorMessage
    {
        get => (string)GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }

    #endregion

    #region Entry

    public static readonly BindableProperty EntryStyleProperty = BindableProperty.Create(nameof(EntryStyle), typeof(Style), typeof(ValidatableEntry), new Style(typeof(Entry)) { });
    public Style EntryStyle
    {
        get => (Style)GetValue(EntryStyleProperty);
        set => SetValue(EntryStyleProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ValidatableEntry), "", BindingMode.TwoWay);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(ValidatableEntry), "Aa...");
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
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

    public ValidatableEntry()
    {
        InitializeComponent();
    }
}