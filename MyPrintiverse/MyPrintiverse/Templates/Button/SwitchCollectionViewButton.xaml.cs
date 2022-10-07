using System.Windows.Input;

namespace MyPrintiverse.Templates.Button;

public partial class SwitchCollectionViewButton : ContentView
{
    #region Action

    public static readonly BindableProperty AddCommandProperty = BindableProperty.Create(nameof(AddCommand), typeof(ICommand), typeof(SwitchCollectionViewButton), null);
    public ICommand AddCommand
    {
        get => (ICommand)GetValue(AddCommandProperty);
        set => SetValue(AddCommandProperty, value);
    }

    #endregion

    #region Image

    public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(SwitchCollectionViewButton), "spool.png");
    public string Source
    {
        get => (string)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    #endregion

    public SwitchCollectionViewButton()
	{
		InitializeComponent();

        //TODO
	}
}