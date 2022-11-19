

using System.Globalization;

namespace MyPrintiverse.Tools.Converters;

public class SelectedItemIsValidConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool real_value = (bool)value;

        if (real_value)
            return "#00000000";
        else
            return Color.FromRgb(212, 33, 33);
       
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}
