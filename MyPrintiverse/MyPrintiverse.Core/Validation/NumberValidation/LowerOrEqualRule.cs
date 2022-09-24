
using MyPrintiverse.Core.Utilities;
using System.Globalization;

namespace MyPrintiverse.Core.Validation.NumberValidation;

/// <summary>
/// Checks if value is lower or equal valueReference.Value.
/// </summary>
public class LowerOrEqualRule : IValidationRule<string>
{
    private ExtendedValidatable<string> ValueReference;


    public LowerOrEqualRule(ExtendedValidatable<string> valueReference)
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
            var a = double.Parse(value.Replace(',', '.'), CultureInfo.InvariantCulture);
            var b = double.Parse(ValueReference.Value.Replace(',', '.'), CultureInfo.InvariantCulture);
            return a <= b;
        }
        catch
        {
            return false;
        }
    }
}
