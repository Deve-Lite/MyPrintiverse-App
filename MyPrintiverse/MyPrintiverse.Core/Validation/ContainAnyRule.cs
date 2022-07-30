namespace MyPrintiverse.Core.Validation;

public class ContainAnyRule : IValidationRule<string>
{
	public string ValidationMessage { get; set; }

	private readonly char[] _characters;

	public ContainAnyRule(params char[] characters)
	{
		_characters = characters;
	}

	public bool Check(string str) => _characters?.Any(requiredCharacter => str.Any(character => character == requiredCharacter)) ?? false;
}