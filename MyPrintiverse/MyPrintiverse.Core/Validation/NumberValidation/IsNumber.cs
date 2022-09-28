using System.Globalization;

namespace MyPrintiverse.Core.Validation.NumberValidation;

public class IsNumber : IValidationRule<string>
{
    public string ValidationMessage { get; set; }

    public bool Check(string value)
    {
        if (value == null)
            return false;

        try
        {
            double.Parse(value.Replace(',', '.'), CultureInfo.InvariantCulture);
        }
        catch
        {
            return false;
        }

        return true;
    }
}
