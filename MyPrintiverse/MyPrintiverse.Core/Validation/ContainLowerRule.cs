namespace MyPrintiverse.Core.Validation;

/// <summary>
/// Check if string contains at least one upper case character.
/// </summary>
public class ContainLowerRule : IValidationRule<string>
{
	public string ValidationMessage { get; set; }

	public bool Check(string str) => str?.Any(char.IsLower) ?? false;
}