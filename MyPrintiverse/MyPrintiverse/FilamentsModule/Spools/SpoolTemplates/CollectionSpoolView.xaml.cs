namespace MyPrintiverse.FilamentsModule.Spools.SpoolTemplates;

public partial class CollectionSpoolView : ContentView
{
    public static readonly BindableProperty AvaliableWeightProperty = BindableProperty.Create(nameof(AvaliableWeight), typeof(string), typeof(DisplaySpoolView), "");
    public string AvaliableWeight
    {
        get => (string)GetValue(AvaliableWeightProperty);
        set => SetValue(AvaliableWeightProperty, value);
    }

    public static readonly BindableProperty StandardWeightProperty = BindableProperty.Create(nameof(StandardWeight), typeof(string), typeof(DisplaySpoolView), "");
    public string StandardWeight
    {
        get => (string)GetValue(StandardWeightProperty);
        set => SetValue(StandardWeightProperty, value);
    }

    public static readonly BindableProperty TagProperty = BindableProperty.Create(nameof(Tag), typeof(string), typeof(DisplaySpoolView), "");
    public string Tag
    {
        get => (string)GetValue(TagProperty);
        set => SetValue(TagProperty, value);
    }

    public static readonly BindableProperty StatusProperty = BindableProperty.Create(nameof(Status), typeof(string), typeof(DisplaySpoolView), "");
    public string Status
    {
        get => (string)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(DisplaySpoolView), "");
    public string Source
    {
        get => (string)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public static readonly BindableProperty EditedAtProperty = BindableProperty.Create(nameof(EditedAt), typeof(string), typeof(DisplaySpoolView), "");
    public string EditedAt
    {
        get => (string)GetValue(EditedAtProperty);
        set => SetValue(EditedAtProperty, value);
    }

    public CollectionSpoolView()
	{
		InitializeComponent();
	}
}