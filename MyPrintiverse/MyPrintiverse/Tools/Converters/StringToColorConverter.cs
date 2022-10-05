
using System.Globalization;

namespace MyPrintiverse.Tools.Converters;

/// <summary>
/// Converts argb / rgb hex string 'XXXXXX' to color.
/// </summary>
public class StringToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var color = (string)value;
        return Color.FromArgb(color.Replace("#", ""));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ((Color)value).ToHex();
    }
}
