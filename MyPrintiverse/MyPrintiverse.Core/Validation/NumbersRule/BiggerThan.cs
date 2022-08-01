
namespace MyPrintiverse.Core.Validation.NumbersRule;

public class BiggerThan<T> : IValidationRule<T>
{
    private int Value;

    public BiggerThan(ref int value)
    {
        Value = value;
    }
    public string ValidationMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool Check(T value)
    {
        throw new NotImplementedException();
    }
}
