

using System.Globalization;

namespace MyPrintiverse.Tools.Converters;

public class StepThreeToBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)value == 3;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return 3;
    }
}
