
using System.Globalization;

namespace MyPrintiverse.Tools.Converters;

public class ColorConverter : IValueConverter
{
    string color;
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Color.FromHex((string)value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ((Color)value).ToHex();
    }
}
