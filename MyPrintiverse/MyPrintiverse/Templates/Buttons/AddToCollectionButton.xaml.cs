using System.Windows.Input;

namespace MyPrintiverse.Templates.Buttons;

public partial class AddToCollectionButton : ContentView
{
    #region Action

    public static readonly BindableProperty AddCommandProperty = BindableProperty.Create(nameof(AddCommand), typeof(ICommand), typeof(AddToCollectionButton), null);
    public ICommand AddCommand
    {
        get => (ICommand)GetValue(AddCommandProperty);
        set => SetValue(AddCommandProperty, value);
    }

    #endregion

    #region Image

    public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(AddToCollectionButton), "add.png");
    public string Source
    {
        get => (string)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    #endregion

    public AddToCollectionButton()
	{
		InitializeComponent();
	}
}