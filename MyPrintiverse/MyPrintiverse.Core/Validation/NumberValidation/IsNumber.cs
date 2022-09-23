
namespace MyPrintiverse.Core.Validation.NumberValidation;

public class IsNumber : IValidationRule<string>
{
    public string ValidationMessage { get; set; }

    //TODO : Fix
    public bool Check(string value)
    {
        if (value == null)

            return false;

        string copy = "";
        if (value.Contains('.'))
            copy = value.Replace('.', ',');
        else
            copy = value;

        return double.TryParse(value, out _) || double.TryParse(copy, out _);
    }
}
