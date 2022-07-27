

using MyPrintiverse.Core.Exceptions;

namespace MyPrintiverse.Core.Validation.NumbersRule;


/// <summary>
/// Rule for validating exponenent length (before ,) in floating point value.
/// </summary>
/// <typeparam name="T"> Floating point type.</typeparam>
public class FloatinPointExponentRule<T> : IValidationRule<T>
{
    private readonly int _exponentLength;

    public FloatinPointExponentRule(int exponentLength)
    {
        if (!IsFolatingPointType())
            throw new InvalidTypeParameterException("Type T must be a integer type.");

        _exponentLength = exponentLength;
    }

    public string ValidationMessage { get; set; }

    public bool Check(T value) => value == null ? false : value.ToString().Split(".,")[0].Length < _exponentLength;

    #region Privates

    private bool IsFolatingPointType()
    {
        switch (Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.Decimal:
            case TypeCode.Double:
            case TypeCode.Single:
                return true;
            default:
                return false;
        }
    }

    #endregion
}
