namespace MyPrintiverse.Templates;

public partial class ValidatableEntry : ContentView
{
    #region Title
    public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle), typeof(Style), typeof(ValidatableEntry), null);
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
    public static readonly BindableProperty ErrorMessageStyleProperty = BindableProperty.Create(nameof(ErrorMessageStyle), typeof(Style), typeof(ValidatableEntry), null);
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

    public static readonly BindableProperty MessageIsVisibleProperty = BindableProperty.Create(nameof(MessageIsVisible), typeof(bool), typeof(ValidatableEntry), false);
    public bool MessageIsVisible
    {
        get => (bool)GetValue(MessageIsVisibleProperty);
        set => SetValue(MessageIsVisibleProperty, value);
    }

    #endregion

    #region Entry
    public static readonly BindableProperty EntryStyleProperty = BindableProperty.Create(nameof(EntryStyle), typeof(Style), typeof(ValidatableEntry), null);
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

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(ValidatableEntry), false);
    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public static readonly BindableProperty EntryConverterProperty = BindableProperty.Create(nameof(EntryConverter), typeof(IValueConverter), typeof(ValidatableEntry), null);
    public IValueConverter EntryConverter
    {
        get => (IValueConverter)GetValue(EntryConverterProperty);
        set => SetValue(EntryConverterProperty, value);
    }

    public static readonly BindableProperty EntryValidationCommandProperty = BindableProperty.Create(nameof(EntryValidationCommand), typeof(Command), typeof(ValidatableEntry), null);
    public Command EntryValidationCommand
    {
        get => (Command)GetValue(EntryValidationCommandProperty);
        set => SetValue(EntryValidationCommandProperty, value);
    }

    #endregion

    public ValidatableEntry()
	{
		InitializeComponent();
	}
}