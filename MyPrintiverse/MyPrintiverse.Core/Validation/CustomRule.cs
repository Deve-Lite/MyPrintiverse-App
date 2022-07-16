namespace MyPrintiverse.Core.Validation;

public class CustomRule<T> : IValidationRule<T>
{
	public string ValidationMessage { get; set; }

	private readonly Func<T, bool> _act;

	public CustomRule(Func<T, bool> act)
	{
		_act = act;
	}

	public bool Check(T obj) => _act(obj);
}