

using MyPrintiverse.FilamentsModule.Filaments;
using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.FilamentsModule.Prints;

public class PrintValidator : BaseValidator<Print>, IMapperValidator<Print>
{
    public Print Map()
    {
        throw new NotImplementedException();
    }
}
