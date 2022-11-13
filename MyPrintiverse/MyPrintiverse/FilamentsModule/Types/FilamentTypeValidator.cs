using CommunityToolkit.Mvvm.ComponentModel;
using MyPrintiverse.Core.Extensions;
using System.Globalization;

namespace MyPrintiverse.FilamentsModule.Types;

[ObservableObject]
public partial class FilamentTypeValidator : BaseValidator<FilamentType>
{
    public ExtendedValidatable<string> ShortName { get; set; }
    public ExtendedValidatable<string> FullName { get; set; }
    public ExtendedValidatable<string> MaxServiceTempearature { get; set; }
    public ExtendedValidatable<string> Density { get; set; }
    public ExtendedValidatable<string> Description { get; set; }

    public ExtendedValidatable<string> NozzleMax { get; set; }
    public ExtendedValidatable<string> NozzleMin { get; set; }

    public ExtendedValidatable<string> BedMax { get; set; }
    public ExtendedValidatable<string> BedMin { get; set; }

    public ExtendedValidatable<string> CoolingMax { get; set; }
    public ExtendedValidatable<string> CoolingMin { get; set; }

    public bool IsUVResistant { get; set; }
    public bool IsFoodFriendly { get; set; }
    public bool IsBio { get; set; }
    public bool IsFlexible { get; set; }
    public bool IsHeatedBedRequired { get; set; }

    [ObservableProperty]
    private string _nozzleTemperatureRange;
    [ObservableProperty]
    private string _bedTemperatureRange;
    [ObservableProperty]
    private string _coolingRange;

    public FilamentTypeValidator()
    { 

        AddValidation();

        InitializeFields();

        InitUnit();
    }

    public FilamentTypeValidator(FilamentType filamentType)
    {

        AddValidation();

        InitializeFields();

        Map(filamentType);

        InitUnit();
    }

    public override bool Validate() => Description.Validate()
                                    && ShortName.Validate()
                                    && FullName.Validate()
                                    && Density.Validate()
                                    && MaxServiceTempearature.Validate()
                                    && BedMin.Validate()
                                    && BedMax.Validate()
                                    && CoolingMin.Validate()
                                    && CoolingMax.Validate()
                                    && NozzleMin.Validate()
                                    && NozzleMax.Validate();

    public override FilamentType Map()
    {
        var FilamentTypeMap = new FilamentType();

        BaseModelMap(FilamentTypeMap);

        /* Parse will not throw Exception because of NumberRules */
        FilamentTypeMap.Density = double.Parse(Density.Value.Replace(',', '.'), CultureInfo.InvariantCulture);
        FilamentTypeMap.MaxServiceTempearature = double.Parse(MaxServiceTempearature.Value.Replace(',', '.'), CultureInfo.InvariantCulture);
        
        FilamentTypeMap.BedTemperatureRange = $"{BedMin.Value}-{BedMax.Value}";
        FilamentTypeMap.NozzleTemperatureRange = $"{NozzleMin.Value}-{NozzleMax.Value}";
        FilamentTypeMap.CoolingRange = $"{CoolingMin.Value}-{CoolingMax.Value}";

        FilamentTypeMap.Description = Description.Value.Trim();
        FilamentTypeMap.ShortName = ShortName.Value;
        FilamentTypeMap.FullName = FullName.Value;

        FilamentTypeMap.IsBio = IsBio;
        FilamentTypeMap.IsFlexible = IsFlexible;
        FilamentTypeMap.IsFoodFriendly = IsFoodFriendly;
        FilamentTypeMap.IsHeatedBedRequired = IsHeatedBedRequired;
        FilamentTypeMap.IsUVResistant = IsUVResistant;

        return FilamentTypeMap;
    }

    #region Privates

    private void AddValidation()
    {
        Description  = ExtendedValidator.Build<string>()
            .WithRule(new RangeRule<string>(maxLength: 500), "Too long data.");
        ShortName  = ExtendedValidator.Build<string>()
            .WithRule(new RangeRule<string>(minLength: 3, maxLength: 20), "Data should have from 3 to 20 characters.\n");
        FullName  = ExtendedValidator.Build<string>()
            .WithRule(new RangeRule<string>(minLength: 3, maxLength: 50), "Data should have from 3 to 50 characters.\n");

        Density  = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new MantissaLengthRule(2), "Too long number mantissa.");
        MaxServiceTempearature  = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new RangeRule<string>(maxLength: 4), "Too long data.");

        BedMin  = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new RangeRule<string>(maxLength: 4), "Too long data.")
            .WithRule(new HasNoDecimalPlace(), "Should be integer");
        BedMax  = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new RangeRule<string>(maxLength: 4), "Too long data.")
            .WithRule(new HasNoDecimalPlace(), "Should be integer")
            .WithRule(new BiggerOrEqualRule(BedMin), "Invalid range."); ;
        CoolingMin  = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new RangeRule<string>(maxLength: 4), "Too long data.")
            .WithRule(new HasNoDecimalPlace(), "Should be integer");
        CoolingMax  = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new RangeRule<string>(maxLength: 4), "Too long data.")
            .WithRule(new HasNoDecimalPlace(), "Should be integer")
            .WithRule(new BiggerOrEqualRule(CoolingMin), "Invalid range."); ;
        NozzleMin  = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new RangeRule<string>(maxLength: 4), "Too long data.")
            .WithRule(new HasNoDecimalPlace(), "Should be integer");
        NozzleMax  = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new RangeRule<string>(maxLength: 4), "Too long data.")
            .WithRule(new HasNoDecimalPlace(), "Should be integer")
            .WithRule(new BiggerOrEqualRule(NozzleMin), "Invalid range."); ;
    }

    private void InitializeFields()
    {
        IsBio = false;
        IsFlexible= false;
        IsFoodFriendly = false;
        IsUVResistant = false;
        IsHeatedBedRequired = false;

        ShortName.Value = "";
        FullName.Value = "";
        Description.Value = "";

        Density.Value = "";
        MaxServiceTempearature.Value = "";
        NozzleMax.Value = "";
        NozzleMin.Value = "";
        BedMax.Value = "";
        BedMin.Value = ""; 
        CoolingMax.Value = "";
        CoolingMin.Value = "";
    }

    public override void Map(FilamentType filamentType)
    {
        // TODO : If edit state save edit data and put into spool only edited data.

        base.Map(filamentType);

        IsBio = filamentType.IsBio;
        IsFlexible= filamentType.IsFlexible;
        IsFoodFriendly = filamentType.IsFoodFriendly;
        IsUVResistant = filamentType.IsUVResistant;
        IsHeatedBedRequired = filamentType.IsHeatedBedRequired;

        ShortName.Value = filamentType.ShortName;
        FullName.Value = filamentType.FullName;
        Description.Value = filamentType.Description;

        Density.Value = filamentType.Density.ToString("0.##");
        MaxServiceTempearature.Value = filamentType.MaxServiceTempearature.ToString();

        var nozzleTemperatures = filamentType.NozzleTemperatureRange.Split('-');
        var bedTemperatures = filamentType.BedTemperatureRange.Split('-');
        var coolingRange = filamentType.CoolingRange.Split('-');

        NozzleMax.Value = nozzleTemperatures[1];
        NozzleMin.Value = nozzleTemperatures[0];
        BedMax.Value = bedTemperatures[1];
        BedMin.Value = bedTemperatures[0];
        CoolingMax.Value = coolingRange[1];
        CoolingMin.Value = coolingRange[0];
    }

    #endregion
}
