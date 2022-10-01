using System.Globalization;

namespace MyPrintiverse.Core.Validation.NumberValidation;

/// <summary>
/// Checks if value is bigger or equal valueReference.Value.
/// </summary>
public class BiggerOrEqualRule : IValidationRule<string>
{
    private ExtendedValidatable<string> ValueReference;


    public BiggerOrEqualRule(ExtendedValidatable<string> valueReference)
    {
        ValueReference = valueReference;
    }

    public string ValidationMessage { get; set; }

    public bool Check(string value)
    {
        if (value == null || ValueReference.Value == null)
            return false;

        try
        {
            var biggerValue = double.Parse(value.Replace(',', '.'), CultureInfo.InvariantCulture);
            var lowerValue = double.Parse(ValueReference.Value.Replace(',', '.'), CultureInfo.InvariantCulture);
            return lowerValue <= biggerValue;
        }
        catch
        {
            return false;
        }
    }
}
