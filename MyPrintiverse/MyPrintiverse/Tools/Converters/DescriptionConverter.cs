using System;
using System.Globalization;

namespace MyPrintiverse.Tools.Converters;

public class DescriptionConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string description = value.ToString();

        if (string.IsNullOrEmpty(description))
            return "No description provided.";


        if(description.Length > 100)
        {
            if (description.Length > 120)
                return description;

            return description.Substring(0, 100) + "...";
        }    

        return description;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}

