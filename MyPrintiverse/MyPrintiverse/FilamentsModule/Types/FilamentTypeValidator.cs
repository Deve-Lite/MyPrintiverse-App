
namespace MyPrintiverse.FilamentsModule.Types;

public class FilamentTypeValidator : BaseValidator<FilamentType>
{
    public FilamentTypeValidator()
    {
        _validatonMode = ValidationMode.Part;

        AddValidation();

        InitUnit();
    }

    public FilamentTypeValidator(FilamentType filamentType)
    {
        _validatonMode = ValidationMode.Full;

        AddValidation();

        FillData(filamentType);

        InitUnit();
    }

    public Validatable<string> ShortName { get; set; }
    public Validatable<string> FullName { get; set; }
    public Validatable<int> MaxServiceTempearature { get; set; }
    public Validatable<double> Density { get; set; }
    public Validatable<string> Description { get; set; }

    public Validatable<int> NozzleMax { get; set; }
    public Validatable<int> NozzleMin { get; set; }

    public Validatable<int> BedMax { get; set; }
    public Validatable<int> BedMin { get; set; }

    public Validatable<int> CoolingMax { get; set; }
    public Validatable<int> CoolingMin { get; set; }

    public bool UVResistant { get; set; }
    public bool IsFoodFriendly { get; set; }
    public bool IsBio { get; set; }
    public bool IsFlexible { get; set; }
    public bool IsHeatedBedRequired { get; set; }

    public override bool Validate()
    {
        return base.Validate();
    }

    public override FilamentType Map()
    {
        var FilamentTypeMap = new FilamentType();

        if (_validatonMode == ValidationMode.Full)
            BaseModelMap(FilamentTypeMap);


        FilamentTypeMap.BedTemperatureRange = $"{BedMin}-{BedMax}";
        FilamentTypeMap.NozzleTemperatureRange = $"{NozzleMin}-{NozzleMax}";
        FilamentTypeMap.CoolingRange = $"{CoolingMin}-{CoolingMax}";
        FilamentTypeMap.MaxServiceTempearature = MaxServiceTempearature.Value;

        FilamentTypeMap.Description = Description.Value;
        FilamentTypeMap.Density = Density.Value;
        FilamentTypeMap.ShortName = ShortName.Value;
        FilamentTypeMap.FullName = FullName.Value;

        FilamentTypeMap.IsBio = IsBio;
        FilamentTypeMap.IsFlexible = IsFlexible;
        FilamentTypeMap.IsFoodFriendly = IsFoodFriendly;
        FilamentTypeMap.IsHeatedBedRequired = IsHeatedBedRequired;
        FilamentTypeMap.IsUVResistant = UVResistant;

        return FilamentTypeMap;
    }

    #region Privates

    private void AddValidation()
    {
        Density = Validator.Build<double>().WithRule(new FloatingPointMantissaRule<double>(4), "Maximal approximation to 4 places!")
            .WithRule(new FloatinPointExponentRule<double>(2), "Invalid density.");

        ShortName = Validator.Build<string>().WithRule(new RangeRule<string>(3, 26), "Brand should be between 3-26 characters.");

        FullName = Validator.Build<string>().WithRule(new RangeRule<string>(3, 26), "Color should be between 3-26 characters.");

        Description = Validator.Build<string>().WithRule(new RangeRule<string>(maxLength: 250), "Description should be shorter than 250 characters.");

        MaxServiceTempearature = Validator.Build<int>().WithRule(new NumberValueRule<int>(0, 999));


    }

    protected override void FillData(FilamentType filamentType)
    {
        base.FillData(filamentType);


        ShortName.Value = filamentType.ShortName;
        FullName.Value = filamentType.FullName;
        Density.Value = filamentType.Density;

        Description.Value = filamentType.Description;

        IsBio = filamentType.IsBio;
        IsFlexible= filamentType.IsFlexible;
        IsFoodFriendly = filamentType.IsFoodFriendly;
        UVResistant = filamentType.IsUVResistant;
        IsHeatedBedRequired = filamentType.IsHeatedBedRequired;
    }

    #endregion
}
