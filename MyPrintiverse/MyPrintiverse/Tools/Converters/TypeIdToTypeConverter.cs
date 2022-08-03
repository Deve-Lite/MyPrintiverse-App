using MyPrintiverse.FilamentsModule.Types;
using MyPrintiverse.FilamentsModule.Types.Services;
using SQLite;
using System.Globalization;

namespace MyPrintiverse.Tools.Converters;


public class TypeIdToTypeConverter : IValueConverter
{

    private readonly SQLiteConnection? db;

    public TypeIdToTypeConverter()
    {
        db = new SQLiteConnection(Path.Combine(FileSystem.AppDataDirectory, $"{nameof(FilamentType)}.db"));
        db.CreateTable<FilamentType>();
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => GetItemAsync((string)value).ShortName;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }

    #region Privates
    private FilamentType GetItemAsync(string objectId)
    {
        try
        {
            return db?.Get<FilamentType>(objectId)!;
        }
        catch
        {
            return new FilamentType { ShortName = "Not Found"};
        }
    }
    #endregion
}
