using System.Windows.Input;

namespace MyPrintiverse.FilamentsModule.FilamentTemplates;

public partial class AddCollectionHeader : ContentView
{
    #region Title

    public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle), typeof(Style), typeof(AddCollectionHeader), null);
    public Style TitleStyle
    {
        get => (Style)GetValue(TitleStyleProperty);
        set => SetValue(TitleStyleProperty, value);
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(AddCollectionHeader), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region Border

    public static readonly BindableProperty BorderStyleProperty = BindableProperty.Create(nameof(BorderStyle), typeof(Style), typeof(AddCollectionHeader), null);
    public Style BorderStyle
    {
        get => (Style)GetValue(BorderStyleProperty);
        set => SetValue(BorderStyleProperty, value);
    }

    #endregion

    #region Add Command

    public static readonly BindableProperty AddCommandProperty = BindableProperty.Create(nameof(AddCommand), typeof(ICommand), typeof(AddCollectionHeader), null);
    public ICommand AddCommand
    {
        get => (ICommand)GetValue(AddCommandProperty);
        set => SetValue(AddCommandProperty, value);
    }

    public static readonly BindableProperty AddSourceProperty = BindableProperty.Create(nameof(AddSource), typeof(string), typeof(ExtendedAddCollectionHeader), "spool.png");
    public string AddSource
    {
        get => (string)GetValue(AddSourceProperty);
        set => SetValue(AddSourceProperty, value);
    }

    #endregion

    public AddCollectionHeader()
	{
		InitializeComponent();
	}
}