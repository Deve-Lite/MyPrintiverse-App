using System.Windows.Input;

namespace MyPrintiverse.FilamentsModule.FilamentTemplates;

public partial class ExtendedAddCollectionHeader : ContentView
{
    #region Title

    public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle), typeof(Style), typeof(CollectionHeader), null);
    public Style TitleStyle
    {
        get => (Style)GetValue(TitleStyleProperty);
        set => SetValue(TitleStyleProperty, value);
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(CollectionHeader), "Title not set.");
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion

    #region StackLayout

    public static readonly BindableProperty StackLayoutStyleProperty = BindableProperty.Create(nameof(StackLayoutStyle), typeof(Style), typeof(CollectionHeader), null);
    public Style StackLayoutStyle
    {
        get => (Style)GetValue(StackLayoutStyleProperty);
        set => SetValue(StackLayoutStyleProperty, value);
    }

    #endregion

    #region Add Command

    public static readonly BindableProperty AddCommandProperty = BindableProperty.Create(nameof(AddCommand), typeof(ICommand), typeof(ExtendedAddCollectionHeader), null);
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

    #region Extending Command

    public static readonly BindableProperty ExtendingCommandProperty = BindableProperty.Create(nameof(ExtendingCommand), typeof(ICommand), typeof(ExtendedAddCollectionHeader), null);
    public ICommand ExtendingCommand
    {
        get => (ICommand)GetValue(ExtendingCommandProperty);
        set => SetValue(ExtendingCommandProperty, value);
    }

    public static readonly BindableProperty ExtendingSourceProperty = BindableProperty.Create(nameof(ExtendingSource), typeof(string), typeof(ExtendedAddCollectionHeader), "spool.png");
    public string ExtendingSource
    {
        get => (string)GetValue(ExtendingSourceProperty);
        set => SetValue(ExtendingSourceProperty, value);
    }

    #endregion

    public ExtendedAddCollectionHeader()
	{
		InitializeComponent();
	}
}