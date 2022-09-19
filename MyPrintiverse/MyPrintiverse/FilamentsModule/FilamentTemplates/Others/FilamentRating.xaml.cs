namespace MyPrintiverse.FilamentsModule.FilamentTemplates.Others;

public partial class FilamentRating : ContentView
{
    #region Rating
    public static readonly BindableProperty RatingProperty = BindableProperty.Create(nameof(Rating), typeof(int), typeof(FilamentRating), 0, propertyChanged: OnRatingChanged);
    public int Rating
    {
        get => (int)GetValue(RatingProperty);
        set => SetValue(RatingProperty, value);
    }

    public static void OnRatingChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var filamentRating = (FilamentRating)bindable;

        if (filamentRating.Rating >= 1)
            filamentRating.BottomImage.Source = "star.svg";
        else
            filamentRating.BottomImage.Source = "emptystar.svg";

        if (filamentRating.Rating >= 2)
            filamentRating.BottomMiddleImage.Source = "star.svg";
        else
            filamentRating.BottomMiddleImage.Source = "emptystar.svg";

        if (filamentRating.Rating >= 3)
            filamentRating.MiddleImage.Source = "star.svg";
        else
            filamentRating.MiddleImage.Source = "emptystar.svg";

        if (filamentRating.Rating >= 4)
            filamentRating.TopMiddleImage.Source = "star.svg";
        else
            filamentRating.TopMiddleImage.Source = "emptystar.svg";

        if (filamentRating.Rating >= 5)
            filamentRating.TopImage.Source = "star.svg";
        else
            filamentRating.TopImage.Source = "emptystar.svg";
    }

    #endregion

    public FilamentRating()
	{
		InitializeComponent();
	}
}