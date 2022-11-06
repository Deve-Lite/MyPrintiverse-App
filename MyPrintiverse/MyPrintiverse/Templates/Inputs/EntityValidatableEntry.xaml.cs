using System.Windows.Input;

namespace MyPrintiverse.Templates.Inputs;

public partial class EntityValidatableEntry : ContentView
{
    #region Heights

    public static readonly BindableProperty TitleHeightProperty = BindableProperty.Create(nameof(TitleHeight), typeof(int), typeof(EntityValidatableEntry), 20);
    public int TitleHeight
    {
        get => (int)GetValue(TitleHeightProperty);
        set => SetValue(TitleHeightProperty, value);
    }

    public static readonly BindableProperty EntryHeightProperty = BindableProperty.Create(nameof(EntryHeight), typeof(int), typeof(EntityValidatableEntry), 50);
    public int EntryHeight
    {
        get => (int)GetValue(EntryHeightProperty);
        set => SetValue(EntryHeightProperty, value);
    }

    public static readonly BindableProperty ErrorMessageLinesProperty = BindableProperty.Create(nameof(ErrorMessageLines), typeof(int), typeof(EntityValidatableEntry), 1, propertyChanged: SetHeight);
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
            bindableEntry.Border.Stroke = bindableEntry.ValidStrokeBrush;
        else
            bindableEntry.Border.Stroke = bindableEntry.InvalidStrokeBrush;
    }

    public static readonly BindableProperty ValidationCommandProperty = BindableProperty.Create(nameof(ValidationCommand), typeof(ICommand), typeof(EntityValidatableEntry), null);
    public ICommand ValidationCommand
    {
        get => (ICommand)GetValue(ValidationCommandProperty);
        set => SetValue(ValidationCommandProperty, value);
    }

    #endregion

    #region Title

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(EntityValidatableEntry), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region ErrorMessage

    public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(EntityValidatableEntry), "");
    public string ErrorMessage
    {
        get => (string)GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }

    #endregion

    #region Entry
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

    public static readonly BindableProperty ValidStrokeBrushProperty = BindableProperty.Create(nameof(InvalidStrokeBrush), typeof(Color), typeof(EntityValidatableEntry), Color.FromArgb("#00000000"));
    public Color ValidStrokeBrush
    {
        get => (Color)GetValue(ValidStrokeBrushProperty);
        set => SetValue(ValidStrokeBrushProperty, value);
    }

    public static readonly BindableProperty InvalidStrokeBrushProperty = BindableProperty.Create(nameof(InvalidStrokeBrush), typeof(Color), typeof(EntityValidatableEntry), Color.FromRgb(212, 33, 33));
    public Color InvalidStrokeBrush
    {
        get => (Color)GetValue(InvalidStrokeBrushProperty);
        set => SetValue(InvalidStrokeBrushProperty, value);
    }

    #endregion

    #region Entity


    public static readonly BindableProperty EntityProperty = BindableProperty.Create(nameof(Entity), typeof(string), typeof(EntityValidatableEntry), "Aa...");
    public string Entity
    {
        get => (string)GetValue(EntityProperty);
        set => SetValue(EntityProperty, value);
    }

    #endregion

    #region Events

    public EventHandler<EventArgs> Completed;

    public void EntryCompleted(object sender, EventArgs e) => Completed.Invoke(sender, e);

    #endregion
    public EntityValidatableEntry()
	{
		InitializeComponent();
	}
}