using MyPrintiverse.Core.Extensions;
using System.Globalization;

namespace MyPrintiverse.Core.Validation.NumberValidation;

public class IsNumber : IValidationRule<string>
{
    public string ValidationMessage { get; set; }

    //TODO : Fix
    public bool Check(string value)
    {
        if (value == null)
            return false;

        if (value.Contains(','))
            value = value.Replace(',', '.');

        try
        {
            double.Parse(value, CultureInfo.InvariantCulture);
        }
        catch
        {
            return false;
        }

        return true;
    }
}
