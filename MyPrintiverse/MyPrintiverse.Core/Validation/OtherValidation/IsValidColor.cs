using System;

namespace MyPrintiverse.Core.Validation.OtherValidation;

/// <summary>
/// 
/// </summary>
public class IsValidColor : IValidationRule<string>
{
    /* Future Validate All Colors  typs */
    public IsValidColor()
    {

    }

    public string ValidationMessage { get; set; }

    public bool Check(string value)
    {
        var allowedCharacters = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        if (string.IsNullOrEmpty(value))
            return false;

        if (!(value.Length%3 == 0) && !(value.Length % 4 == 0))
            return false;

        foreach(char data in value)
            if (!allowedCharacters.Any(x => x == data))
                return false;

        return true;
    }
}

