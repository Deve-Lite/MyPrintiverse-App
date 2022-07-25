
using System.Globalization;

namespace MyPrintiverse.Templates.Test;

/// <summary>
/// Class for breakpoints to check if is converting 
/// </summary>
public class TestConventer : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Console.Write(value.ToString());
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Console.Write(value.ToString());
        return value;
    }
}
