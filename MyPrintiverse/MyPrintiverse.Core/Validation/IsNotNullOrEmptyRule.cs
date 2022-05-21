namespace MyPrintiverse.Core.Validation;

public class IsNotNullOrEmptyRule : IValidationRule<string>
{
	public string ValidationMessage { get; set; }

	public bool Check(string str) => !string.IsNullOrEmpty(str);
}