namespace MyPrintiverse.Templates;

public partial class EntityValidatableEntry : ContentView
{
    #region Entry Grid
    // sets height of entry grid (sometimes weird height problem)

    public static readonly BindableProperty SupportHeightProperty = BindableProperty.Create(nameof(SupportHeight), typeof(int), typeof(EntityValidatableEntry), 50);
    public int SupportHeight
    {
        get => (int)GetValue(SupportHeightProperty);
        set => SetValue(SupportHeightProperty, value);
    }

    #endregion

    #region Validation

    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(EntityValidatableEntry), false, BindingMode.TwoWay, propertyChanged: OnIsValidChanged);
    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    private static void OnIsValidChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableEntry = (EntityValidatableEntry)bindable;

        if (bindableEntry.IsValid)
            bindableEntry.Border.Stroke = Color.FromArgb("#00000000");
        else
            bindableEntry.Border.Stroke = Color.FromRgb(212, 33, 33);
    }

    public static readonly BindableProperty ValidationCommandProperty = BindableProperty.Create(nameof(ValidationCommand), typeof(ICommand), typeof(EntityValidatableEntry), null);
    public ICommand ValidationCommand
    {
        get => (ICommand)GetValue(ValidationCommandProperty);
        set => SetValue(ValidationCommandProperty, value);
    }

    #endregion

    #region Title
    public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle), typeof(Style), typeof(EntityValidatableEntry), new Style(typeof(Label)) { });
    public Style TitleStyle
    {
        get => (Style)GetValue(TitleStyleProperty);
        set => SetValue(TitleStyleProperty, value);
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(EntityValidatableEntry), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region ErrorMessage
    public static readonly BindableProperty ErrorMessageStyleProperty = BindableProperty.Create(nameof(ErrorMessageStyle), typeof(Style), typeof(EntityValidatableEntry), new Style(typeof(Label)) { }, propertyChanged: SetHeight);
    public Style ErrorMessageStyle
    {
        get => (Style)GetValue(ErrorMessageStyleProperty);
        set => SetValue(ErrorMessageStyleProperty, value);
    }

    public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(EntityValidatableEntry), "");
    public string ErrorMessage
    {
        get => (string)GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }

    public static readonly BindableProperty ErrorMessageLinesProperty = BindableProperty.Create(nameof(ErrorMessageLines), typeof(int), typeof(EntityValidatableEntry), 1);
    public int ErrorMessageLines
    {
        get => (int)GetValue(ErrorMessageLinesProperty);
        set => SetValue(ErrorMessageLinesProperty, value);
    }

    private static void SetHeight(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableEntry = (EntityValidatableEntry)bindable;

        bindableEntry.errorMessage.HeightRequest = bindableEntry.ErrorMessageLines * ((int)bindableEntry.errorMessage.FontSize + 2);
    }

    #endregion

    #region Entry

    public static readonly BindableProperty EntryStyleProperty = BindableProperty.Create(nameof(EntryStyle), typeof(Style), typeof(EntityValidatableEntry), new Style(typeof(Entry)) { });
    public Style EntryStyle
    {
        get => (Style)GetValue(EntryStyleProperty);
        set => SetValue(EntryStyleProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(EntityValidatableEntry), "", BindingMode.TwoWay);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(EntityValidatableEntry), "Aa...");
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(EntityValidatableEntry), false);
    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    #endregion

    #region Border

    public static readonly BindableProperty BorderStyleProperty = BindableProperty.Create(nameof(BorderStyle), typeof(Style), typeof(EntityValidatableEntry), null);
    public Style BorderStyle
    {
        get => (Style)GetValue(BorderStyleProperty);
        set => SetValue(BorderStyleProperty, value);
    }

    #endregion

    #region Entity
    public static readonly BindableProperty EntityStyleProperty = BindableProperty.Create(nameof(EntityStyle), typeof(Style), typeof(ExtendedEntityValidatableEntry), new Style(typeof(Label)) { });
    public Style EntityStyle
    {
        get => (Style)GetValue(EntityStyleProperty);
        set => SetValue(EntityStyleProperty, value);
    }

    public static readonly BindableProperty EntityProperty = BindableProperty.Create(nameof(Entity), typeof(string), typeof(ExtendedEntityValidatableEntry), "");
    public string Entity
    {
        get => (string)GetValue(EntityProperty);
        set => SetValue(EntityProperty, value);
    }

    #endregion

    public EntityValidatableEntry()
	{
		InitializeComponent();
        Margin = new Thickness(10, 4, 10, 4);
    }
}