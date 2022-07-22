using System.Windows.Input;

namespace MyPrintiverse.Templates;

public partial class ValidatableEntryWithButton : ContentView
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

    public static readonly BindableProperty ErrorMessageIsVisibleProperty = BindableProperty.Create(nameof(ErrorMessageIsVisible), typeof(bool), typeof(ValidatableEntry), false);
    public bool ErrorMessageIsVisible
    {
        get => (bool)GetValue(ErrorMessageIsVisibleProperty);
        set => SetValue(ErrorMessageIsVisibleProperty, value);
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

    public static readonly BindableProperty EntryValidationCommandProperty = BindableProperty.Create(nameof(EntryValidationCommand), typeof(ICommand), typeof(ValidatableEntry), null);
    public ICommand EntryValidationCommand
    {
        get => (ICommand)GetValue(EntryValidationCommandProperty);
        set => SetValue(EntryValidationCommandProperty, value);
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

    #region ImagineButton
    public static readonly BindableProperty ImagineButtonProperty = BindableProperty.Create(nameof(ImagineButtonStyle), typeof(Style), typeof(ValidatableEntry), null);
    public Style ImagineButtonStyle
    {
        get => (Style)GetValue(ImagineButtonProperty);
        set => SetValue(ImagineButtonProperty, value);
    }

    public static readonly BindableProperty ImageButtonCommandProperty = BindableProperty.Create(nameof(ImageButtonCommand), typeof(ICommand), typeof(ValidatableEntry), null);
    public ICommand ImageButtonCommand
    {
        get => (ICommand)GetValue(ImageButtonCommandProperty);
        set => SetValue(ImageButtonCommandProperty, value);
    }

    public static readonly BindableProperty ImageButtonSourceProperty = BindableProperty.Create(nameof(ImageButtonSource), typeof(string), typeof(ValidatableEntry), "spool.png");
    public string ImageButtonSource
    {
        get => (string)GetValue(ImageButtonSourceProperty);
        set => SetValue(ImageButtonSourceProperty, value);
    }

    #endregion

    public ValidatableEntryWithButton()
	{
		InitializeComponent();
	}
}