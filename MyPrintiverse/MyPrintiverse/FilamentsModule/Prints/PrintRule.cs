

using MyPrintiverse.FilamentsModule.Filaments;
using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.FilamentsModule.Prints;

public class PrintRule : IValidationRule<Spool>
{
    public string ValidationMessage { get; set; }

    public bool Check(Spool value)
    {
        throw new NotImplementedException();
    }
}
