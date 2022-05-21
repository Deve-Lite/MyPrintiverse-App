namespace MyPrintiverse.Core.Validation;

public class ContainAllRule : IValidationRule<string>
{
	public string ValidationMessage { get; set; }

	private readonly char[] _characters;

	public ContainAllRule(params char[] characters)
	{
		_characters = characters ?? throw new ArgumentNullException();
	}

	public bool Check(string str) => _characters.All(requiredCharacter => str.Any(character => character == requiredCharacter));
}