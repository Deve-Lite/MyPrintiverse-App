namespace MyPrintiverse.FilamentsModule.FilamentTemplates.Others;

public partial class StepDescription : ContentView
{
    #region Title

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(StepDescription), "MyPrintiverse");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region Title

    public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(StepDescription), "MyPrintiverse");
    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    #endregion

    #region Title

    public static readonly BindableProperty StepProperty = BindableProperty.Create(nameof(Step), typeof(string), typeof(StepDescription), "MyPrintiverse");
    public string Step
    {
        get => (string)GetValue(StepProperty);
        set => SetValue(StepProperty, value);
    }

    #endregion


    public StepDescription()
	{
		InitializeComponent();
	}
}