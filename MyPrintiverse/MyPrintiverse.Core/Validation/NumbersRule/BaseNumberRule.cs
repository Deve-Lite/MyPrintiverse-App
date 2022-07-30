

namespace MyPrintiverse.Core.Validation.NumbersRule;

public abstract class BaseNumberRule<T>
{
    protected bool IsNumberType() => IsIntegerType() || IsFolatingPointType();

    protected bool IsIntegerType()
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

    protected bool IsFolatingPointType()
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
}
