using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.Tools.Validation;

public class OnlyLettersRule : IValidationRule<string>
{
	public string ValidationMessage { get; set; }

	public bool Check(string str) => str.All(char.IsLetter);
}