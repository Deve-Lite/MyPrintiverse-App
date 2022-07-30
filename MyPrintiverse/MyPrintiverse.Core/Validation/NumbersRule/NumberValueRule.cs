
using MyPrintiverse.Core.Exceptions;

namespace MyPrintiverse.Core.Validation.NumbersRule;

/// <summary>
/// Terminates whether value is lower or equal upper bound and bigger or equal than lower bound.
/// </summary>
/// <typeparam name="T"></typeparam>
public class NumberValueRule<T> : BaseNumberRule<T>, IValidationRule<T> where T : IComparable<T>
{
    private readonly T _lowerBound;
    private readonly T _upperBound;
    private readonly string _valueTooBigText;
    private readonly string _valueTooSmallText;


    public NumberValueRule(T lowerBound, T upperBound, string valueTooSmallText, string valueTooBigText)
    {
        if (!IsNumberType())
            throw new InvalidTypeParameterException("T should be numeric type.");

        _lowerBound = lowerBound;
        _upperBound = upperBound;
        _valueTooBigText = valueTooBigText;
        _valueTooSmallText = valueTooSmallText;
    }

    public NumberValueRule(T lowerBound, T upperBound)
    {
        if (!IsNumberType())
            throw new InvalidTypeParameterException("T should be numeric type.");

        _lowerBound = lowerBound;
        _upperBound = upperBound;
        _valueTooBigText = $"Value should be smaller than {_upperBound}.";
        _valueTooSmallText = $"Value should be greater than {_lowerBound}.";
    }

    public string ValidationMessage { get; set; }

    public bool Check(T value)
    {
        if (value == null)
            return false;

        if (value.CompareTo(_lowerBound) < 0)
        {
            ValidationMessage = _valueTooSmallText;
            return false;
        }

        if (value.CompareTo(_upperBound) > 0)
        {
            ValidationMessage = _valueTooBigText;
            return false;
        }

        return true;
    }
}
