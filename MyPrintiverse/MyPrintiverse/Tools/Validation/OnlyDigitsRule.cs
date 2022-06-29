using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.Tools.Validation;

public class OnlyDigitsRule : IValidationRule<string>
{
	public string ValidationMessage { get; set; }

	public bool Check(string str) => str.All(char.IsDigit);
}