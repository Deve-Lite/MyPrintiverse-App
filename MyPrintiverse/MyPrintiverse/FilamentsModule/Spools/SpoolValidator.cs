
using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.FilamentsModule.Spools;
public class SpoolValidator : BaseValidator<Spool>, IMapperValidator<Spool>
{

    public Spool Map()
    {
        throw new NotImplementedException("Implement SpoolValidator.");
    }
}
