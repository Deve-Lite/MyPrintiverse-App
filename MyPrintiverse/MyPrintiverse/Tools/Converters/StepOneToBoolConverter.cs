﻿

using System.Globalization;

namespace MyPrintiverse.Tools.Converters;

public class StepOneToBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)value == 1;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return 1;
    }
}
