namespace MyPrintiverse.Core.Validation;

/// <summary>
/// Check if string contains at least one digit.
/// </summary>
public class ContainDigitsRule : IValidationRule<string>
{
	public string ValidationMessage { get; set; }

	public bool Check(string str) => str?.Any(char.IsNumber) ?? false;
}