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
            filamentRating.BottomImage.Source = "star.png";
        else
            filamentRating.BottomImage.Source = "emptystar.png";

        if (filamentRating.Rating >= 2)
            filamentRating.BottomMiddleImage.Source = "star.png";
        else
            filamentRating.BottomMiddleImage.Source = "emptystar.png";

        if (filamentRating.Rating >= 3)
            filamentRating.MiddleImage.Source = "star.png";
        else
            filamentRating.MiddleImage.Source = "emptystar.png";

        if (filamentRating.Rating >= 4)
            filamentRating.TopMiddleImage.Source = "star.png";
        else
            filamentRating.TopMiddleImage.Source = "emptystar.png";

        if (filamentRating.Rating >= 5)
            filamentRating.TopImage.Source = "star.png";
        else
            filamentRating.TopImage.Source = "emptystar.png";
    }

    #endregion

    public FilamentRating()
	{
		InitializeComponent();
	}
}