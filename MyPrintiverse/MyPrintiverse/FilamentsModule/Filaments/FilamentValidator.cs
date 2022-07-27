namespace MyPrintiverse.FilamentsModule.Filaments;

public class FilamentValidator : Validator<Filament>
{
    public Validatable<string> Id { get; set; }
    public Validatable<string> TypeId { get; set; }
    public Validatable<DateTime> CreatedAt { get; set; }
    public Validatable<DateTime> EditedAt { get; set; }
    public Validatable<double> Diameter { get; set; }
    public Validatable<string> Brand { get; set; }
    public Validatable<string> ColorName { get; set; }
    public Validatable<Color> Color { get; set; }
    public Validatable<string> ShortDescription { get; set; }

    public FilamentValidator(ValidationMode validationMode)
    {
        if(validationMode == ValidationMode.Full)
        {

        }
        else
        {

        }
    }
    public FilamentValidator(Filament filament, ValidationMode validationMode)
    {
        if (validationMode == ValidationMode.Full)
        {

        }
        else
        {

        }
    }

    public override Filament Map()
    {
        var fialmentMap = new Filament
        {
            
        };
        return fialmentMap;
    }
}
