namespace MyPrintiverse.Templates;

public partial class RatingSelector : ContentView
{
    public static readonly BindableProperty RatingProperty = BindableProperty.Create(nameof(Rating), typeof(int), typeof(RatingSelector), -1, BindingMode.TwoWay, propertyChanged: OnRatingChanged);
    public int Rating
    {
        get => (int)GetValue(RatingProperty);
        set => SetValue(RatingProperty, value);
    }

    private static void OnRatingChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var selector = (RatingSelector)bindable;

        SetImages(selector);
    }

    public RatingSelector()
    {
        InitializeComponent();
    }

    #region Tapps

    void ImageZeroTapped(System.Object sender, System.EventArgs e)
    {
        Rating = 1;
    }

    void ImageOneTapped(System.Object sender, System.EventArgs e)
    {
        Rating = 2;
    }

    void ImageTwoTapped(System.Object sender, System.EventArgs e)
    {
        Rating = 3;
    }

    void ImageThreeTapped(System.Object sender, System.EventArgs e)
    {
        Rating = 4;
    }

    void ImageFourTapped(System.Object sender, System.EventArgs e)
    {
        Rating = 5;
    }

    #endregion

    private static void SetImages(RatingSelector selector)
    {
        SetImage(selector.ImageZero, selector.Rating >= 1);
        SetImage(selector.ImageOne, selector.Rating >= 2);
        SetImage(selector.ImageTwo, selector.Rating >= 3);
        SetImage(selector.ImageThree, selector.Rating >= 4);
        SetImage(selector.ImageFour, selector.Rating >= 5);
    }

    private static void SetImage(Image image, bool isFullStar)
    {
        if (isFullStar)
            image.Source = "star.svg";
        else
            image.Source = "emptystar.svg";
    }
}
