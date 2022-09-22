namespace MyPrintiverse.Core.Validation.NumberValidation;

public class ExponentLengthRule : IValidationRule<string>
{
    private readonly int _maxExponentLength;
    private readonly int _minExponentLength;
    public ExponentLengthRule(int minMantissaLength, int maxMantissaLength)
    {
        _maxExponentLength = maxMantissaLength;
        _minExponentLength = minMantissaLength;
    }

    public ExponentLengthRule(int maxMantissaLength)
    {
        _maxExponentLength = maxMantissaLength;
        _minExponentLength = -1;
    }

    public string ValidationMessage { get; set; }

    public bool Check(string value)
    {
        if (value == null)
            return false;

        string[] data = value.Split(".,");

        if (data.Length < 1)
            return false;

        int exponentLength = data[0].Length;

        return _minExponentLength <= exponentLength && exponentLength <= _maxExponentLength;
    }
}
