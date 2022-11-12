using System.Windows.Input;

namespace MyPrintiverse.Templates.Forms;

public partial class TopManageBar : ContentView
{
    #region TopBar

    public static readonly BindableProperty BackCommandProperty = BindableProperty.Create(nameof(BackCommand), typeof(ICommand), typeof(TopManageBar), null);
    public ICommand BackCommand
    {
        get => (ICommand)GetValue(BackCommandProperty);
        set => SetValue(BackCommandProperty, value);
    }

    public static readonly BindableProperty BackSourceProperty = BindableProperty.Create(nameof(BackSource), typeof(string), typeof(TopManageBar), "spool.png");
    public string BackSource
    {
        get => (string)GetValue(BackSourceProperty);
        set => SetValue(BackSourceProperty, value);
    }

    #endregion

    public TopManageBar()
	{
		InitializeComponent();
	}
}