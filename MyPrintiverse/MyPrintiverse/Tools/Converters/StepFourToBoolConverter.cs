

using System.Globalization;

namespace MyPrintiverse.Tools.Converters;

public class StepFourToBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)value == 4;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return 4;
    }
}
