using System.Windows.Input;

namespace MyPrintiverse.FilamentsModule.Spools.ManageSpoolViews;

public partial class SpoolStepOneView : ContentView
{
    #region Commands

    public static readonly BindableProperty BackCommandProperty = BindableProperty.Create(nameof(BackCommand), typeof(ICommand), typeof(SpoolStepOneView), null);
    public ICommand BackCommand
    {
        get => (ICommand)GetValue(BackCommandProperty);
        set => SetValue(BackCommandProperty, value);
    }

    public static readonly BindableProperty NextStepCommandProperty = BindableProperty.Create(nameof(NextStepCommand), typeof(ICommand), typeof(SpoolStepOneView), null);
    public ICommand NextStepCommand
    {
        get => (ICommand)GetValue(NextStepCommandProperty);
        set => SetValue(NextStepCommandProperty, value);
    }

    public static readonly BindableProperty IsRunningProperty = BindableProperty.Create(nameof(IsRunning), typeof(bool), typeof(SpoolStepOneView), false);
    public bool IsRunning
    {
        get => (bool)GetValue(IsRunningProperty);
        set => SetValue(IsRunningProperty, value);
    }

    #endregion

    #region Spool

    public static readonly BindableProperty SpoolProperty = BindableProperty.Create(nameof(Spool), typeof(Validator<Spool>), typeof(SpoolStepOneView), null);
    public Validator<Spool> Spool
    {
        get => (Validator<Spool>)GetValue(SpoolProperty);
        set => SetValue(SpoolProperty, value);
    }

    #endregion

    public SpoolStepOneView()
	{
		InitializeComponent();
	}
}