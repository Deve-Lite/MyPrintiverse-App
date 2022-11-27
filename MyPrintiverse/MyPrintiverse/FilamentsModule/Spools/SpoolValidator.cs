
using MongoDB.Bson;
using MyPrintiverse.Core.Extensions;
using System.Globalization;

namespace MyPrintiverse.FilamentsModule.Spools;

public class SpoolValidator : BaseValidator<Spool>
{
    public string FilamentId { get; set; }

    public ExtendedValidatable<string> Description { get; set; }
    public ExtendedValidatable<string> StandardWeight { get; set; }
    public ExtendedValidatable<string> AvaliableWeight { get; set; }
    public ExtendedValidatable<string> Cost { get; set; }
    public ExtendedValidatable<string> Tag { get; set; }

    public ExtendedValidatable<bool> IsFinished { get; set; }
    public ExtendedValidatable<bool> IsOnSpool { get; set; }

    public SpoolValidator()
    {
        AddValidation();

        InitializeFields();

        InitUnit();
    }

    public SpoolValidator(Spool spool)
    {
        AddValidation();

        InitializeFields();

        Map(spool);

        InitUnit();
    }

    public override bool Validate() => Cost.Validate() &&
                                       Tag.Validate() &&
                                       StandardWeight.Validate() &&
                                       AvaliableWeight.Validate() &&     
                                       Description.Validate();

    public override Spool Map()
    {
        var spoolMap = new Spool();

        BaseModelMap(spoolMap);

        spoolMap.FilamentId = FilamentId;
        spoolMap.Description = Description.Value.Trim();
        spoolMap.IsFinished = IsFinished.Value;
        spoolMap.IsOnSpool = IsOnSpool.Value;
        spoolMap.Tag = Tag.Value;

        /* Parse will not throw Exception because of NumberRules */
        spoolMap.AvaliableWeight = double.Parse(AvaliableWeight.Value.Trim().Replace(',', '.'), CultureInfo.InvariantCulture);
        spoolMap.StandardWeight = double.Parse(StandardWeight.Value.Trim().Replace(',', '.'), CultureInfo.InvariantCulture);
        spoolMap.Cost = double.Parse(Cost.Value.Trim().Replace(',', '.'), CultureInfo.InvariantCulture);

        return spoolMap;
    }

    #region Privates

    private void AddValidation()
    {
        Cost =  ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new MantissaLengthRule(2), "Too long number mantissa.");

        StandardWeight = ExtendedValidator.Build<string>()
            .WithRule(new IsNumber(), "Data is not a valid number.")
            .WithRule(new MantissaLengthRule(3), "Too long number mantissa.");

        AvaliableWeight = ExtendedValidator.Build<string>()
            .WithRule( new IsNumber(), "Data is not a valid number.")
            .WithRule( new MantissaLengthRule(3), "Too long number mantissa.")
            .WithRule( new LowerOrEqualRule(StandardWeight), "Should be lower than standard weight.");

        Tag = ExtendedValidator.Build<string>()
            .WithRule(new RangeRule<string>(minLength: 3, maxLength: 10), "Data should have from 3 to 10 characters.\n");

        Description = ExtendedValidator.Build<string>()
            .WithRule(new RangeRule<string>(maxLength:500), "Too long data.");

        IsOnSpool = ExtendedValidator.Build<bool>();

        IsFinished = ExtendedValidator.Build<bool>();
    }

    private void InitializeFields()
    {
        IsOnSpool.Value = true;
        IsFinished.Value = false;
        Cost.Value = ""; 
        AvaliableWeight.Value = "";
        StandardWeight.Value = "";
        Description.Value = "";
        FilamentId = "";
        Tag.Value = "";
    }

    public override void Map(Spool spool)
    {
        // TODO : If edit state save edit data and put into spool only edited data.

        base.Map(spool);

        FilamentId = spool.FilamentId;

        IsFinished.Value = spool.IsFinished;
        IsOnSpool.Value = spool.IsOnSpool;

        AvaliableWeight.Value = spool.AvaliableWeight.ToString("0.###");
        StandardWeight.Value = spool.StandardWeight.ToString("0.###");
        Cost.Value = spool.Cost.ToString("0.##");
        Tag.Value = spool.Tag;

        Description.Value = spool.Description;
    }

    #endregion
}
