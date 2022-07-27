
using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.FilamentsModule.Spools;
public class SpoolRule : IValidationRule<Spool>
{
    public string ValidationMessage { get; set; }

    public bool Check(Spool value)
    {
        throw new NotImplementedException();
    }
}
