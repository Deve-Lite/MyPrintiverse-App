using MyPrintiverse.Core.Exceptions;

namespace MyPrintiverse.Core.Validation.NumbersRule;

/// <summary>
/// Rule for validating length of integer type value.
/// </summary>
/// <typeparam name="T"> Integer type value. </typeparam>
public class IntegerTypeLengthRule<T> : BaseNumberRule<T>, IValidationRule<T>
{
    private readonly int _maxDigits;

    public IntegerTypeLengthRule(int maxDigits)
    {
        if (!IsIntegerType())
            throw new InvalidTypeParameterException("Type T must be a integer type.");

        _maxDigits = maxDigits;
    }


    public string ValidationMessage { get; set; }

    public bool Check(T value) => value == null ? false : value.ToString().Length < _maxDigits;
}
