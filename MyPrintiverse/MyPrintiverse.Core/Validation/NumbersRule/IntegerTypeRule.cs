using MyPrintiverse.Core.Exceptions;

namespace MyPrintiverse.Core.Validation.NumbersRule;

/// <summary>
/// Rule for validating length of integer type value.
/// </summary>
/// <typeparam name="T"> Integer type value. </typeparam>
public class IntegerTypeRule<T> : IValidationRule<T>
{
    private readonly int _maxDigits;

    public IntegerTypeRule(int maxDigits)
    {
        if (!IsIntegerType())
            throw new InvalidTypeParameterException("Type T must be a integer type.");

        _maxDigits = maxDigits;
    }


    public string ValidationMessage { get; set; }

    public bool Check(T value) => value == null ? false : value.ToString().Length < _maxDigits;

    #region Privates 

    private bool IsIntegerType()
    {
        switch (Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.Byte:
            case TypeCode.SByte:
            case TypeCode.UInt16:
            case TypeCode.UInt32:
            case TypeCode.UInt64:
            case TypeCode.Int16:
            case TypeCode.Int32:
            case TypeCode.Int64:
                return true;
            default:
                return false;
        }
    }

    #endregion
}
