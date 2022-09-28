

namespace MyPrintiverse.Core.Validation.NumberValidation;

public class HasNoDecimalPlace : IValidationRule<string>
{
    public string ValidationMessage { get; set; }

    public bool Check(string value)
    {
        return !value.Contains('.') && !value.Contains(',');
    }
}
