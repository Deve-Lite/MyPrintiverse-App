
using MyPrintiverse.Core.Validation.NumberValidation;

namespace MyPrintiverse.FilamentsModule.Spools;

public class SpoolValidator : BaseValidator<Spool>
{
    public string FilamentId { get; set; }

    public ExtendedValidatable<string> Description { get; set; }
    public ExtendedValidatable<string> StandardWeight { get; set; }
    public ExtendedValidatable<string> AvaliableWeight { get; set; }
    public ExtendedValidatable<string> Cost { get; set; }

    public bool IsFinished { get; set; }
    public bool IsOnSpool { get; set; }


    public SpoolValidator()
    {
        AddValidation();

        InitUnit();
    }

    public SpoolValidator(Spool spool)
    {
        AddValidation();

        Map(spool);

        InitUnit();
    }

    public override bool Validate() => AvaliableWeight.Validate() && 
                                       StandardWeight.Validate() &&     
                                       Description.Validate() &&
                                       Cost.Validate();

    public override Spool Map()
    {
        var spoolMap = new Spool();

        BaseModelMap(spoolMap);

        spoolMap.FilamentId = FilamentId;
        spoolMap.Description = Description.Value;
        spoolMap.IsFinished = IsFinished;
        spoolMap.IsSample = IsOnSpool;
        // TODO
        // Check conversion!.
        spoolMap.AvaliableWeight = Convert.ToDouble(AvaliableWeight.Value);
        spoolMap.StandardWeight = Convert.ToDouble(StandardWeight.Value);
        spoolMap.Cost = Convert.ToDouble(Cost.Value);

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
            .WithRule( new MantissaLengthRule(3), "Too long number mantissa.");



        Description = ExtendedValidator.Build<string>();
    }

    protected override void Map(Spool spool)
    {
        base.Map(spool);

        FilamentId = spool.FilamentId;

        IsFinished = spool.IsFinished;
        IsOnSpool = spool.IsSample;

        AvaliableWeight.Value = spool.AvaliableWeight.ToString("0.###");
        StandardWeight.Value = spool.StandardWeight.ToString("0.###");
        Cost.Value = spool.Cost.ToString("0.##");

        Description.Value = spool.Description;
    }

    #endregion
}
