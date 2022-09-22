
namespace MyPrintiverse.Core.Validation.NumberValidation;

public class IsNumber : IValidationRule<string>
{
    public string ValidationMessage { get; set; }

    public bool Check(string value) => double.TryParse(value, out _);
}
