using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.FilamentsModule.Filaments;

public class FilamentValidator : BaseValidator<Filament>, IMapperValidator<Filament>
{
    public string TypeId { get; set; }
    public Validatable<double> Diameter { get; set; }
    public Validatable<string> Brand { get; set; }
    public Validatable<string> Color { get; set; }
    public string ColorHex { get; set; }
    public Validatable<string> ShortDescription { get; set; }
    public Validatable<int> NozzleTemperature { get; set; }
    public Validatable<int> CoolingTemperature { get; set; }
    public Validatable<int> BedTemperature { get; set; }
    public Validatable<int> Rating { get; set; }

    public FilamentValidator()
    {
        _validatonMode = ValidationMode.Part;

        AddValidation();
    }
    public FilamentValidator(Filament filament)
    {
        _validatonMode = ValidationMode.Full;

        AddValidation();
    }

    public Filament Map()
    {
        var fialmentMap = new Filament();

        if (_validatonMode == ValidationMode.Full)
        {
            BaseModelMap(fialmentMap);
        }

        fialmentMap.TypeId = TypeId;
        fialmentMap.Diameter = Diameter.Value;
        fialmentMap.Brand = Brand.Value;
        fialmentMap.ShortDescription = ShortDescription.Value;
        fialmentMap.Color = Color.Value;
        fialmentMap.ColorHex = ColorHex;
        fialmentMap.BedTemperature = BedTemperature.Value;
        fialmentMap.CoolingTemperature = CoolingTemperature.Value;
        fialmentMap.NozzleTemperature = NozzleTemperature.Value;
        fialmentMap.Rating = Rating.Value;

        return fialmentMap;
    }

    #region Privates

    private void AddValidation()
    {

        Diameter = Validator.Build<double>()
            .WithRule(new FloatingPointMantissaRule<double>(2), "Maximal approximation to 2 places!")
            .WithRule(new FloatinPointExponentRule<double>(6), "Invalid diameter.");

        Brand = Validator.Build<string>().WithRule(new RangeRule<string>(3, 26), "Brand should be between 3-26 characters.");

        Color = Validator.Build<string>().WithRule(new RangeRule<string>(3, 26), "Color should be between 3-26 characters.");

        if (_validatonMode == ValidationMode.Full)
        {
            ShortDescription = Validator.Build<string>().WithRule(new RangeRule<string>(maxLength:100), "Description should be shorter than 100 characters.");

            NozzleTemperature = Validator.Build<int>().WithLengthRule(1, 3, "Value rage 0-999");

            BedTemperature = Validator.Build<int>().WithLengthRule(1, 3, "Value rage 0-999");

            CoolingTemperature = Validator.Build<int>().WithLengthRule(1, 3, "Value rage 0-999");

            Rating = Validator.Build<int>().WithRule(new NumberValueRule<int>(0, 10));
        }
        else
        {
            ShortDescription.IsValid = true;
            NozzleTemperature.IsValid = true;
            BedTemperature.IsValid = true;
            CoolingTemperature.IsValid = true;
            Rating.IsValid = true;
        }
    }

    #endregion
}
