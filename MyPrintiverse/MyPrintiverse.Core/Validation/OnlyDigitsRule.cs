namespace MyPrintiverse.Core.Validation;

public class OnlyDigitsRule : IValidationRule<string>
{
	public string ValidationMessage { get; set; }

	public bool Check(string str) => str == null ? false : str.All(char.IsDigit);
}