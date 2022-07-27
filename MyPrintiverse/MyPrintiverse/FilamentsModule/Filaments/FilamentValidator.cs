
using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.FilamentsModule.Filaments;

public class FilamentValidator : BaseValidator<Filament>, IMapperValidator<Filament>
{
    private readonly ValidationMode _validatonMode;

    public Validatable<string> TypeId { get; set; }
    public Validatable<double> Diameter { get; set; }
    public Validatable<string> Brand { get; set; }
    public Validatable<string> ColorHex { get; set; }
    public Validatable<string> Color { get; set; }
    public Validatable<string> ShortDescription { get; set; }

    public FilamentValidator(ValidationMode validationMode)
    {
        _validatonMode = validationMode;

        if (validationMode == ValidationMode.Full)
        {

        }
        else
        {

        }
    }
    public FilamentValidator(Filament filament, ValidationMode validationMode)
    {
        _validatonMode = validationMode;

        if (validationMode == ValidationMode.Full)
        {

        }
        else
        {

        }
    }

    public Filament Map()
    {
        var fialmentMap = new Filament();

        if (_validatonMode == ValidationMode.Full)
        {
            BaseModelMap(fialmentMap);
        }

        fialmentMap.Diameter = Diameter.Value;
        fialmentMap.Brand = Brand.Value;
        fialmentMap.ShortDescription = ShortDescription.Value;
        fialmentMap.Color = Color.Value;
        fialmentMap.ColorHex = ColorHex.Value;
        fialmentMap.TypeId = TypeId.Value;

        return fialmentMap;
    }
}
