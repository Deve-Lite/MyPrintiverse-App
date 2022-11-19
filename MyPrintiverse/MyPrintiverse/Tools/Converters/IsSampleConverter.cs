
using System.Globalization;

namespace MyPrintiverse.Tools.Converters;

public class IsSampleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((bool)value)
            return "Not on spool";

        return "On spool";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}
