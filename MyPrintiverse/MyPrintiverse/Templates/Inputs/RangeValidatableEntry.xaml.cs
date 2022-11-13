using System.Windows.Input;

namespace MyPrintiverse.Templates.Inputs;

public partial class RangeValidatableEntry : ContentView
{
    #region Heights

    public static readonly BindableProperty TitleHeightProperty = BindableProperty.Create(nameof(TitleHeight), typeof(int), typeof(RangeValidatableEntry), 20);
    public int TitleHeight
    {
        get => (int)GetValue(TitleHeightProperty);
        set => SetValue(TitleHeightProperty, value);
    }

    public static readonly BindableProperty EntryHeightProperty = BindableProperty.Create(nameof(EntryHeight), typeof(int), typeof(RangeValidatableEntry), 50);
    public int EntryHeight
    {
        get => (int)GetValue(EntryHeightProperty);
        set => SetValue(EntryHeightProperty, value);
    }

    public static readonly BindableProperty ErrorMessageLinesProperty = BindableProperty.Create(nameof(ErrorMessageLines), typeof(int), typeof(RangeValidatableEntry), 1, propertyChanged: SetHeight);
    public int ErrorMessageLines
    {
        get => (int)GetValue(ErrorMessageLinesProperty);
        set => SetValue(ErrorMessageLinesProperty, value);
    }

    private static void SetHeight(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableEntry = (RangeValidatableEntry)bindable;

        bindableEntry.errorMessage.HeightRequest = bindableEntry.ErrorMessageLines * ((int)bindableEntry.errorMessage.FontSize + 2);
    }

    #endregion

    #region EntryRight

    public static readonly BindableProperty TextRightProperty = BindableProperty.Create(nameof(TextRight), typeof(string), typeof(RangeValidatableEntry), "", BindingMode.TwoWay);
    public string TextRight
    {
        get => (string)GetValue(TextRightProperty);
        set => SetValue(TextRightProperty, value);
    }

    public static readonly BindableProperty IsRightValidProperty = BindableProperty.Create(nameof(IsRightValid), typeof(bool), typeof(RangeValidatableEntry), false, BindingMode.TwoWay, propertyChanged: OnIsRightValidChanged);
    public bool IsRightValid
    {
        get => (bool)GetValue(IsRightValidProperty);
        set => SetValue(IsRightValidProperty, value);
    }

    private static void OnIsRightValidChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableEntry = (RangeValidatableEntry)bindable;

        if (bindableEntry.IsRightValid)
            bindableEntry.BorderRight.Stroke = Color.FromArgb("#00000000");
        else
            bindableEntry.BorderRight.Stroke = Color.FromRgb(212, 33, 33);
    }

    #endregion

    #region EntryLeft

    public static readonly BindableProperty TextLeftProperty = BindableProperty.Create(nameof(TextLeft), typeof(string), typeof(RangeValidatableEntry), "", BindingMode.TwoWay);
    public string TextLeft
    {
        get => (string)GetValue(TextLeftProperty);
        set => SetValue(TextLeftProperty, value);
    }

    public static readonly BindableProperty IsLeftValidProperty = BindableProperty.Create(nameof(IsLeftValid), typeof(bool), typeof(RangeValidatableEntry), false, BindingMode.TwoWay, propertyChanged: OnIsLeftValidChanged);
    public bool IsLeftValid
    {
        get => (bool)GetValue(IsLeftValidProperty);
        set => SetValue(IsLeftValidProperty, value);
    }

    private static void OnIsLeftValidChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableEntry = (RangeValidatableEntry)bindable;

        if (bindableEntry.IsLeftValid)
            bindableEntry.BorderLeft.Stroke = Color.FromArgb("#00000000");
        else
            bindableEntry.BorderLeft.Stroke = Color.FromRgb(212, 33, 33);
    }

    #endregion

    #region Common Entry

    public static readonly BindableProperty ValidationCommandProperty = BindableProperty.Create(nameof(ValidationCommand), typeof(ICommand), typeof(RangeValidatableEntry), null);
    public ICommand ValidationCommand
    {
        get => (ICommand)GetValue(ValidationCommandProperty);
        set => SetValue(ValidationCommandProperty, value);
    }

    #endregion

    #region Entity

    public static readonly BindableProperty EntityProperty = BindableProperty.Create(nameof(Entity), typeof(string), typeof(RangeValidatableEntry), "");
    public string Entity
    {
        get => (string)GetValue(EntityProperty);
        set => SetValue(EntityProperty, value);
    }

    #endregion

    #region Title

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(RangeValidatableEntry), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region ErrorMessage

    public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(RangeValidatableEntry), "");
    public string ErrorMessage
    {
        get => (string)GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }

    #endregion

    #region Events

    public EventHandler<EventArgs> LCompleted;

    public void LEntryCompleted(object sender, EventArgs e)
    {
        if (LCompleted == null)
        {
            REntry.Focus();
            return;
        }
        LCompleted(sender, e);
    }

    public EventHandler<EventArgs> RCompleted;

    public void REntryCompleted(object sender, EventArgs e)
    {
        if (RCompleted == null)
            return;
        RCompleted(sender, e);
    }

    #endregion

    public RangeValidatableEntry()
	{
		InitializeComponent();
        LEntry.Keyboard = Keyboard.Numeric;
        REntry.Keyboard = Keyboard.Numeric;
	}
}