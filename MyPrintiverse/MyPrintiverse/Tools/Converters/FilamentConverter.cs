
using MyPrintiverse.FilamentsModule.Types;
using MyPrintiverse.FilamentsModule.Types.Services;
using System.Globalization;

namespace MyPrintiverse.Tools.Converters;

//TODO 
public class FilamentConverter : IValueConverter
{

    private FilamentTypeDeviceService filamentTypeService;
    public FilamentConverter()
    {
        // rozwiazanie tymczasowe tutaj trzeba ogarnac zeby jakos zgarniac ten serwis z dependency injection
        filamentTypeService = new FilamentTypeDeviceService();
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        //var x = filamentTypeService.GetItemAsync((string)value);

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
