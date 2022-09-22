
namespace MyPrintiverse.FilamentsModule.Filaments;

public class FilamentValidator : BaseValidator<Filament>
{
    #region Properties
    public string TypeId { get; set; }
    public Validatable<double> Diameter { get; set; }
    public Validatable<string> Brand { get; set; }
    public Validatable<string> Color { get; set; }
    public string ColorHex { get; set; }
    public Validatable<string> ShortDescription { get; set; }
    public Validatable<int> NozzleTemperature { get; set; }
    public Validatable<int> CoolingRate { get; set; }
    public Validatable<int> BedTemperature { get; set; }
    public Validatable<int> Rating { get; set; }

    #endregion

    public FilamentValidator()
    {

        AddValidation();

        InitUnit();
    }
    public FilamentValidator(Filament filament)
    {

        AddValidation();

        Map(filament);

        InitUnit();
    }

    public override bool Validate() => base.Validate();

    public override Filament Map()
    {
        var fialmentMap = new Filament();
        
        fialmentMap.TypeId = TypeId;
        fialmentMap.Diameter = Diameter.Value;
        fialmentMap.Brand = Brand.Value;
        fialmentMap.Description = ShortDescription.Value;
        fialmentMap.ColorName = Color.Value;
        fialmentMap.ColorHex = ColorHex;
        fialmentMap.BedTemperature = BedTemperature.Value;
        fialmentMap.CoolingRate = CoolingRate.Value;
        fialmentMap.NozzleTemperature = NozzleTemperature.Value;
        fialmentMap.Rating = Rating.Value;

        return fialmentMap;
    }

    #region Privates

    private void AddValidation()
    {

        Diameter = Validator.Build<double>();

        Brand = Validator.Build<string>().WithRule(new RangeRule<string>(3, 26), "Brand should be between 3-26 characters.");

        Color = Validator.Build<string>().WithRule(new RangeRule<string>(3, 26), "Color should be between 3-26 characters.");

        if (true)
        {
            ShortDescription = Validator.Build<string>().WithRule(new RangeRule<string>(maxLength:100), "Description should be shorter than 100 characters.");

            
        }
        else
        {
            ShortDescription = Validator.Build<string>();
            NozzleTemperature = Validator.Build<int>();
            BedTemperature = Validator.Build<int>();
            CoolingRate = Validator.Build<int>();
            Rating = Validator.Build<int>();

            ShortDescription.IsValid = true;
            NozzleTemperature.IsValid = true;
            BedTemperature.IsValid = true;
            CoolingRate.IsValid = true;
            Rating.IsValid = true;
        }
    }

    protected override void Map(Filament filament)
    {
        base.Map(filament);

        TypeId = filament.TypeId;
        ColorHex = filament.ColorHex;

        Color.Value = filament.ColorName;
        Diameter.Value = filament.Diameter;
        Brand.Value = filament.Brand;

        ShortDescription.Value = filament.Description;
        NozzleTemperature.Value = filament.NozzleTemperature;
        BedTemperature.Value = filament.BedTemperature;
        CoolingRate.Value = filament.CoolingRate;
        Rating.Value = filament.Rating;
    }

    #endregion
}
