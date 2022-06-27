

using MyPrintiverse.FilamentsModule.Filaments;
using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.Tools.Validation;

public class FilamentRule : IValidationRule<Filament>
{
    public string ValidationMessage { get; set; }

    public bool Check(Filament value)
    {
        if (value == null) 
            return false;

        //TODO

        return true;
    }
}
