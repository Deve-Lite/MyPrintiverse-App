

namespace MyPrintiverse.Core.Validation.NumberValidation;

public class MantissaLengthRule : IValidationRule<string>
{
    private readonly int _maxMantissaLength;
    private readonly int _minMantissaLength;
    public MantissaLengthRule(int minMantissaLength, int maxMantissaLength)
    {
        _maxMantissaLength = maxMantissaLength;
        _minMantissaLength = minMantissaLength;
    }

    public MantissaLengthRule(int maxMantissaLength)
    {
        _maxMantissaLength = maxMantissaLength;
        _minMantissaLength = -1;
    }

    public string ValidationMessage { get; set; }

    public bool Check(string value)
    {
        if (value == null)
            return false;

        string[] data = value.Split('.',',');

        if (data.Length <= 1)
            return true;

        int mantissaLength = data[1].Length;

        return  _minMantissaLength <= mantissaLength && mantissaLength <= _maxMantissaLength;
    }
}
