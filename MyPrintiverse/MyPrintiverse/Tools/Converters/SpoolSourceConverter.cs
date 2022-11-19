
using System.Globalization;

namespace MyPrintiverse.Tools.Converters;

public class SpoolSourceConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        try {
            bool isSample = (bool)values[0];
            bool isFisnished = (bool)values[1];

            double standardWeight = (double)values[2];
            double avaliableWeight = (double)values[3];

            /*To change when icons arrive*/

            if (isSample)
                return "rope.png";

            if (isFisnished)
                return "spoolempty.png";

            if (standardWeight <= 2* avaliableWeight)
                return "fullspool.png";

            return "spoolempty.png";
        }
        catch (Exception ex) { return "spoolempty.png";  }
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        return null;
    }
}
