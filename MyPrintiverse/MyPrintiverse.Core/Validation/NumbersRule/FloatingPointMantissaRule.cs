using MyPrintiverse.Core.Exceptions;

namespace MyPrintiverse.Core.Validation.NumbersRule;

/// <summary>
/// Rule for validating mantissa length (after ,) in floating point value.
/// </summary>
/// <typeparam name="T"> Floating point type.</typeparam>
public class FloatingPointMantissaRule<T> : BaseNumberRule<T>, IValidationRule<T>
{
    private readonly int _mantissaLength;

    public FloatingPointMantissaRule(int mantissaLength)
    {
        if (!IsFolatingPointType())
            throw new InvalidTypeParameterException("Type T must be a integer type.");

        _mantissaLength = mantissaLength;
    }

    public string ValidationMessage { get; set; }

    public bool Check(T value) => value == null ? false : value.ToString().Split(".,")[1].Length < _mantissaLength;
}
