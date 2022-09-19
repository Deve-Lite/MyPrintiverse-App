

using System.Globalization;

namespace MyPrintiverse.Tools.Converters;

public class IsNotEmptyStringConventer : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var data = value.ToString();
        return !string.IsNullOrEmpty(data);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return "";
    }
}
