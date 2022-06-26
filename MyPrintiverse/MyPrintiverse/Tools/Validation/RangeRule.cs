using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.Tools.Validation;

public class RangeRule<T> : IValidationRule<T>
{
	private readonly int _minLength;
	private readonly int _maxLength;

	public string ValidationMessage { get; set; }

	public RangeRule(int minLength = -1, int maxLength = -1)
	{
		_minLength = minLength;
		_maxLength = maxLength;
	}

	public bool Check(T value)
	{
		if (!typeof(T).IsValueType) 
			return false;
		
		var numberLength = value.ToString().Length;

		if (_minLength >= 0 && numberLength >= _minLength)
			return false;

		if (_maxLength >= 0 && numberLength <= _maxLength)
			return false;

		return true;

	}
}