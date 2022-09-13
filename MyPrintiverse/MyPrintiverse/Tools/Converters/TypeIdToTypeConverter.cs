using MyPrintiverse.FilamentsModule.Types;
using SQLite;
using System.Globalization;
using System.Linq;

namespace MyPrintiverse.Tools.Converters;


public class TypeIdToTypeConverter : IValueConverter
{

    private readonly SQLiteConnection? db;

    public TypeIdToTypeConverter()
    {
        var link = Path.Combine(FileSystem.AppDataDirectory, $"{nameof(FilamentType)}.db");
        db = new SQLiteConnection(Path.Combine(link));
        db.CreateTable<FilamentType>();
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => GetItem((string)value);

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }

    #region Privates
    private string GetItem(string objectId)
    {
        try
        {
            return db!.Table<FilamentType>().First(x => x.Id == objectId).ShortName;
        }
        catch (Exception e)
        {
            return "Not Found";
        }
    }
    #endregion
}
