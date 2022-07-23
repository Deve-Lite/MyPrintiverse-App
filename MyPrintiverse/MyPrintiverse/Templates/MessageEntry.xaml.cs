namespace MyPrintiverse.Templates;

public partial class MessageEntry : ContentView
{
    //TODO
    public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(MessageEntry), string.Empty);

	public string Message
	{
		get => (string)GetValue(MessageEntry.MessageProperty);
		set => SetValue(MessageEntry.MessageProperty, value);
	}

	public static readonly BindableProperty MessageIsVisibleProperty = BindableProperty.Create(nameof(MessageIsVisible), typeof(bool), typeof(MessageEntry), false);

	public bool MessageIsVisible
	{
		get => (bool)GetValue(MessageIsVisibleProperty);
		set => SetValue(MessageIsVisibleProperty, value);
	}

	public static readonly BindableProperty MessageColorProperty = BindableProperty.Create(nameof(MessageColor), typeof(Color), typeof(MessageEntry), Color.FromRgb(255, 255, 255));

	public Color MessageColor
	{
		get => (Color)GetValue(MessageColorProperty);
		set => SetValue(MessageColorProperty, value);
	}

	public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(MessageEntry), string.Empty);

	public string Placeholder
	{
		get => (string)GetValue(PlaceholderProperty);
		set => SetValue(PlaceholderProperty, value);
	}

	public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(MessageEntry), string.Empty);

	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public MessageEntry()
	{
		InitializeComponent();
	}
}