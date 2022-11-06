using System.Windows.Input;
using MyPrintiverse.Tools.Templates;

namespace MyPrintiverse.Templates.Inputs;

public partial class ValidatableEntry : ContentView
{
    #region Heights

    public static readonly BindableProperty TitleHeightProperty = BindableProperty.Create(nameof(TitleHeight), typeof(int), typeof(ValidatableEntry), 20);
    public int TitleHeight
    {
        get => (int)GetValue(TitleHeightProperty);
        set => SetValue(TitleHeightProperty, value);
    }

    public static readonly BindableProperty EntryHeightProperty = BindableProperty.Create(nameof(EntryHeight), typeof(int), typeof(ValidatableEntry), 50);
    public int EntryHeight
    {
        get => (int)GetValue(EntryHeightProperty);
        set => SetValue(EntryHeightProperty, value);
    }

    public static readonly BindableProperty ErrorMessageLinesProperty = BindableProperty.Create(nameof(ErrorMessageLines), typeof(int), typeof(ValidatableEntry), 1, propertyChanged: SetHeight);
    public int ErrorMessageLines
    {
        get => (int)GetValue(ErrorMessageLinesProperty);
        set => SetValue(ErrorMessageLinesProperty, value);
    }

    private static void SetHeight(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableEntry = (ValidatableEntry)bindable;

        bindableEntry.errorMessage.HeightRequest = bindableEntry.ErrorMessageLines * ((int)bindableEntry.errorMessage.FontSize + 2);
    }

    #endregion

    #region Validation

    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(ValidatableEntry), false, BindingMode.TwoWay, propertyChanged: OnIsValidChanged);
    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }
    private static void OnIsValidChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableEntry = (ValidatableEntry)bindable;

        if (bindableEntry.IsValid)
            bindableEntry.Border.Stroke = bindableEntry.ValidStrokeBrush;
        else
            bindableEntry.Border.Stroke = bindableEntry.InvalidStrokeBrush;
    }

    public static readonly BindableProperty ValidationCommandProperty = BindableProperty.Create(nameof(ValidationCommand), typeof(ICommand), typeof(ValidatableEntry), null);
    public ICommand ValidationCommand
    {
        get => (ICommand)GetValue(ValidationCommandProperty);
        set => SetValue(ValidationCommandProperty, value);
    }

    #endregion

    #region Title

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ValidatableEntry), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region ErrorMessage

    public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(ValidatableEntry), "");
    public string ErrorMessage
    {
        get => (string)GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }

    #endregion

    #region Entry
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

    public static readonly BindableProperty KeyboardTypeProperty = BindableProperty.Create(nameof(KeyboardType), typeof(Keyboards), typeof(ValidatableEntry), Keyboards.Default, propertyChanged:SetKeyboard);
    public Keyboards KeyboardType
    {
        get => (Keyboards)GetValue(KeyboardTypeProperty);
        set => SetValue(KeyboardTypeProperty, value);
    }

    public static readonly BindableProperty KeyboardFlagProperty = BindableProperty.Create(nameof(KeyboardFlag), typeof(KeyboardFlags), typeof(ValidatableEntry), KeyboardFlags.None, propertyChanged: SetKeyboard);
    public KeyboardFlags KeyboardFlag
    {
        get => (KeyboardFlags)GetValue(KeyboardFlagProperty);
        set => SetValue(KeyboardFlagProperty, value);
    }

    private static void SetKeyboard(BindableObject bindable, object oldValue, object newValue)
    { 
        ValidatableEntry entry = (ValidatableEntry)bindable;

        entry.Entry.Keyboard = KeyboardsExtensions.Map(entry.KeyboardType);
        entry.Entry.Keyboard = Keyboard.Create(entry.KeyboardFlag);
    }

    #endregion

    #region Border

    public static readonly BindableProperty ValidStrokeBrushProperty = BindableProperty.Create(nameof(InvalidStrokeBrush), typeof(Color), typeof(ValidatableEntry), Color.FromArgb("#00000000"));
    public Color ValidStrokeBrush
    {
        get => (Color)GetValue(ValidStrokeBrushProperty);
        set => SetValue(ValidStrokeBrushProperty, value);
    }

    public static readonly BindableProperty InvalidStrokeBrushProperty = BindableProperty.Create(nameof(InvalidStrokeBrush), typeof(Color), typeof(ValidatableEntry), Color.FromRgb(212, 33, 33));
    public Color InvalidStrokeBrush
    {
        get => (Color)GetValue(InvalidStrokeBrushProperty);
        set => SetValue(InvalidStrokeBrushProperty, value);
    }

    #endregion

    #region Events

    public EventHandler<EventArgs> Completed;

    public void EntryCompleted(object sender, EventArgs e) => Completed.Invoke(sender, e);

    #endregion

    public ValidatableEntry()
	{
		InitializeComponent();
	}
}