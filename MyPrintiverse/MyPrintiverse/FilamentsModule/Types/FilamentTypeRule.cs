
using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.FilamentsModule.Types;
public class FilamentTypeRule : IValidationRule<FilamentType>
{
    public string ValidationMessage { get; set; }

    public bool Check(FilamentType value)
    {
        throw new NotImplementedException();
    }
}
