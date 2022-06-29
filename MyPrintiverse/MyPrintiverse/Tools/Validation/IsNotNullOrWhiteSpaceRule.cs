using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.Tools.Validation;

public class IsNotNullOrWhiteSpaceRule : IValidationRule<string>
{
	public string ValidationMessage { get; set; }

	public bool Check(string str) => !string.IsNullOrWhiteSpace(str);
}