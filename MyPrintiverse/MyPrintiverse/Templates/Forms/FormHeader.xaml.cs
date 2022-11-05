namespace MyPrintiverse.Templates.Forms;

public partial class FormHeader : ContentView
{

    #region Title

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(FormHeader), "MyPrintiverse");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region StepDescription

    public static readonly BindableProperty StepDescriptionProperty = BindableProperty.Create(nameof(StepDescription), typeof(string), typeof(FormHeader), "MyPrintiverse");
    public string StepDescription
    {
        get => (string)GetValue(StepDescriptionProperty);
        set => SetValue(StepDescriptionProperty, value);
    }

    #endregion

    #region Step

    public static readonly BindableProperty StepProperty = BindableProperty.Create(nameof(Step), typeof(int), typeof(FormHeader), 1);
    public int Step
    {
        get => (int)GetValue(StepProperty);
        set => SetValue(StepProperty, value);
    }

    public static readonly BindableProperty TotalStepsProperty = BindableProperty.Create(nameof(TotalSteps), typeof(int), typeof(FormFooter), 1);
    public int TotalSteps
    {
        get => (int)GetValue(TotalStepsProperty);
        set => SetValue(TotalStepsProperty, value);
    }

    #endregion

    public FormHeader()
	{
		InitializeComponent();
	}
}