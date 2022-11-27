
using System.Windows.Input;

namespace MyPrintiverse.Templates.Forms;

public partial class FormFooter : ContentView
{

    #region Footer Data

    public static readonly BindableProperty StepProperty = BindableProperty.Create(nameof(Step), typeof(int), typeof(FormFooter), 1, propertyChanged: StepChanged);
    public int Step
    {
        get => (int)GetValue(StepProperty);
        set => SetValue(StepProperty, value);
    }

    public static readonly BindableProperty TotalStepsProperty = BindableProperty.Create(nameof(TotalSteps), typeof(int), typeof(FormFooter), 2);
    public int TotalSteps
    {
        get => (int)GetValue(TotalStepsProperty);
        set => SetValue(TotalStepsProperty, value);
    }

    #endregion

    #region Buttons

    public static readonly BindableProperty PreviousStepTextProperty = BindableProperty.Create(nameof(PreviousStepText), typeof(string), typeof(FormFooter), "BACK");
    public string PreviousStepText
    {
        get => (string)GetValue(PreviousStepTextProperty);
        set => SetValue(PreviousStepTextProperty, value);
    }

    public static readonly BindableProperty NextStepTextProperty = BindableProperty.Create(nameof(NextStepText), typeof(string), typeof(FormFooter), "NEXT");
    public string NextStepText
    {
        get => (string)GetValue(NextStepTextProperty);
        set => SetValue(NextStepTextProperty, value);
    }

    public static readonly BindableProperty FinishingStepTextProperty = BindableProperty.Create(nameof(FinishingStepText), typeof(string), typeof(FormFooter), "ADD");
    public string FinishingStepText
    {
        get => (string)GetValue(FinishingStepTextProperty);
        set => SetValue(FinishingStepTextProperty, value);
    }

    public static readonly BindableProperty IsNextButtonRunningProperty = BindableProperty.Create(nameof(IsNextButtonRunning), typeof(bool), typeof(FormFooter), false);
    public bool IsNextButtonRunning
    {
        get => (bool)GetValue(IsNextButtonRunningProperty);
        set => SetValue(IsNextButtonRunningProperty, value);
    }

    public static readonly BindableProperty IsPreviousButtonRunningProperty = BindableProperty.Create(nameof(IsPreviousButtonRunning), typeof(bool), typeof(FormFooter), false);
    public bool IsPreviousButtonRunning
    {
        get => (bool)GetValue(IsPreviousButtonRunningProperty);
        set => SetValue(IsPreviousButtonRunningProperty, value);
    }

    #endregion 


    #region Actions

    public static readonly BindableProperty NextStepCommandProperty = BindableProperty.Create(nameof(NextStepCommand), typeof(ICommand), typeof(FormFooter), null);
    public ICommand NextStepCommand
    {
        get => (ICommand)GetValue(NextStepCommandProperty);
        set => SetValue(NextStepCommandProperty, value);
    }

    public static readonly BindableProperty PreviousStepCommandProperty = BindableProperty.Create(nameof(PreviousStepCommand), typeof(ICommand), typeof(FormFooter), null);
    public ICommand PreviousStepCommand
    {
        get => (ICommand)GetValue(PreviousStepCommandProperty);
        set => SetValue(PreviousStepCommandProperty, value);
    }

    #endregion

    #region Property Changed

    private static void StepChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var bindableFooter = (FormFooter)bindable;
        byte actstep = Convert.ToByte(newValue);

        if (bindableFooter.TotalSteps == 1)
            return;

        if (actstep == bindableFooter.TotalSteps)
        {
            if (bindableFooter.previousButton.IsVisible == false)
                bindableFooter.previousButton.IsVisible = true;

            bindableFooter.nextButton.Text = bindableFooter.FinishingStepText;
        }
        else if (actstep == 1)
        {
            bindableFooter.previousButton.IsVisible = false;
            bindableFooter.nextButton.Text = bindableFooter.NextStepText;
        }
        else 
        {
            if(bindableFooter.previousButton.IsVisible == false)
                bindableFooter.previousButton.IsVisible = true;

            bindableFooter.nextButton.Text = bindableFooter.NextStepText;
        }
    }

    #endregion

    public FormFooter()
	{
		InitializeComponent();

        // TODO : Animacje znikania i pojawienia przycisku 

        if (TotalSteps == 1)
            nextButton.Text = FinishingStepText;
        else
            nextButton.Text = NextStepText;
	}
}