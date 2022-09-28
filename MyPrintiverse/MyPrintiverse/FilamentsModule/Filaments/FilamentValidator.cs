
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
    public ExtendedValidatable<string> ShortDescription { get; set; }
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
                                       ShortDescription.Validate() &&
                                       NozzleTemperature.Validate() &&
                                       CoolingRate.Validate() &&
                                       BedTemperature.Validate() &&
                                       Rating.Validate();

    public override Filament Map()
    {
        var fialmentMap = new Filament();
        
        fialmentMap.TypeId = TypeId;
        fialmentMap.Brand = Brand.Value;
        fialmentMap.Description = ShortDescription.Value;
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

        ShortDescription.Value = "";
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

        Diameter = ExtendedValidator.Build<string>();
        Brand = ExtendedValidator.Build<string>();
        Color = ExtendedValidator.Build<string>();

        ShortDescription = ExtendedValidator.Build<string>();
        NozzleTemperature = ExtendedValidator.Build<string>();
        BedTemperature = ExtendedValidator.Build<string>();
        CoolingRate = ExtendedValidator.Build<string>();
        Rating = ExtendedValidator.Build<string>();
    }

    public override void Map(Filament filament)
    {
        base.Map(filament);

        TypeId = filament.TypeId;
        ColorHex = filament.ColorHex;

        ShortDescription.Value = filament.Description;
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
