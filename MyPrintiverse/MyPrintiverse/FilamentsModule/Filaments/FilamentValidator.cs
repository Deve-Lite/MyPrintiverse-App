
using MyPrintiverse.Core.Extensions;
using System.Globalization;

namespace MyPrintiverse.FilamentsModule.Filaments;

public class FilamentValidator : BaseValidator<Filament>
{
    #region Properties
    public string TypeId { get; set; }
    public ExtendedValidatable<string> Diameter { get; set; }
    public ExtendedValidatable<string> Brand { get; set; }
    public ExtendedValidatable<string> Color { get; set; }
    public string ColorHex { get; set; }
    public ExtendedValidatable<string> Description { get; set; }
    public ExtendedValidatable<string> NozzleTemperature { get; set; }
    public ExtendedValidatable<string> CoolingRate { get; set; }
    public ExtendedValidatable<string> BedTemperature { get; set; }
    public ExtendedValidatable<string> Rating { get; set; }

    #endregion

    public FilamentValidator()
    {
        AddValidation();

        InitializeFields();

        InitUnit();
    }
    public FilamentValidator(Filament filament)
    {

        AddValidation();

        InitializeFields();

        Map(filament);

        InitUnit();
    }

    public override bool Validate() => Diameter.Validate() &&
                                       Brand.Validate() &&
                                       Color.Validate() &&
                                       Description.Validate() &&
                                       NozzleTemperature.Validate() &&
                                       CoolingRate.Validate() &&
                                       BedTemperature.Validate() &&
                                       Rating.Validate();

    public override Filament Map()
    {
        var fialmentMap = new Filament();
        
        fialmentMap.TypeId = TypeId;
        fialmentMap.Brand = Brand.Value;
        fialmentMap.Description = Description.Value;
        fialmentMap.ColorName = Color.Value;
        fialmentMap.ColorHex = ColorHex;

        /* Parse will not throw Exception because of NumberRules */
        fialmentMap.Diameter = double.Parse(Diameter.Value.Replace(',', '.'), CultureInfo.InvariantCulture);
        fialmentMap.BedTemperature = int.Parse(BedTemperature.Value.Replace(',', '.'), CultureInfo.InvariantCulture);
        fialmentMap.CoolingRate = int.Parse(CoolingRate.Value, CultureInfo.InvariantCulture);
        fialmentMap.NozzleTemperature = int.Parse(NozzleTemperature.Value.Replace(',', '.'), CultureInfo.InvariantCulture);
        fialmentMap.Rating = int.Parse(Rating.Value.Replace(',', '.'), CultureInfo.InvariantCulture);

        return fialmentMap;
    }

    #region Privates

    private void InitializeFields()
    {
        TypeId = "";
        ColorHex = "";

        Description.Value = "";
        Color.Value = "";
        Brand.Value = "";

        Diameter.Value = "";
        NozzleTemperature.Value = "";
        BedTemperature.Value = "";
        CoolingRate.Value = "";
        Rating.Value = "";
    }

    private void AddValidation()
    {

        Diameter = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new MantissaLengthRule(2), "Too long number mantissa.");
        Brand = ExtendedValidator.Build<string>()
            .WithRule(new RangeRule<string>(minLength: 3, maxLength: 50), "Too long data.");
        Color = ExtendedValidator.Build<string>()
            .WithRule(new RangeRule<string>(minLength: 3, maxLength: 50), "Too long data.");

        Description = ExtendedValidator.Build<string>()
            .WithRule(new RangeRule<string>(maxLength: 500), "Too long data.");
        NozzleTemperature = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new HasNoDecimalPlace(), "Should be integer")
            .WithRule(new RangeRule<string>(maxLength: 4), "Too long data.");
        BedTemperature = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new HasNoDecimalPlace(), "Should be integer")
            .WithRule(new RangeRule<string>(maxLength: 4), "Too long data.");
        CoolingRate = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new HasNoDecimalPlace(), "Should be integer")
            .WithRule(new RangeRule<string>(maxLength: 4), "Too long data.");

        // TODO : Change to some clicking 
        Rating = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new HasNoDecimalPlace(), "Should be integer");
    }

    public override void Map(Filament filament)
    {
        base.Map(filament);

        TypeId = filament.TypeId;
        ColorHex = filament.ColorHex;

        Description.Value = filament.Description;
        Color.Value = filament.ColorName;
        Brand.Value = filament.Brand;


        Diameter.Value = filament.Diameter.ToString("0.##");
        NozzleTemperature.Value = filament.NozzleTemperature.ToString();
        BedTemperature.Value = filament.BedTemperature.ToString();
        CoolingRate.Value = filament.CoolingRate.ToString();
        Rating.Value = filament.Rating.ToString();
    }

    #endregion
}
