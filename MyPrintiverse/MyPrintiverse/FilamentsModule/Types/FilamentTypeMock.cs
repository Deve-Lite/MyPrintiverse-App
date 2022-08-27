namespace MyPrintiverse.FilamentsModule.Types;

public class FilamentTypeMock : BaseMock<FilamentType>
{
    public FilamentType GenerateFilamentType()
    {
        var item = new FilamentType();

        var name = GetRandomFromList(Names);
        item.ShortName = name.Item1;
        item.FullName = name.Item2;

        item.MaxServiceTempearature = Rand(150);
        item.BedTemperatureRange = $"{Rand(40, 50)}-{Rand(50, 90)}";
        item.NozzleTemperatureRange = $"{Rand(190, 210)}-{Rand(210, 230)}";
        item.CoolingRange = $"{Rand(0, 50)}-{Rand(50, 100)}";
        item.Density = Rand(1.5);
        item.Description = GetRandomFromList(Decriptions);

        item.IsFlexible = Rand();
        item.IsBio = Rand();
        item.IsUVResistant = Rand();
        item.IsFoodFriendly = Rand();
        item.IsHeatedBedRequired = Rand();

        return item;
    }

    private List<Tuple<string, string>> Names = new List<Tuple<string, string>>
    {
        Tuple.Create("PLA", "Polylactic acid"),
        Tuple.Create("PETG", "Polyethylene terephthalate glycol"),
        Tuple.Create("ABS", "Acrylonitrile butadiene styrene"),
        Tuple.Create("ASA", "Acrylonitrile Styrene Acrylate"),
        Tuple.Create("FLEX40", "Flexible"),
        Tuple.Create("OWN", "Random mix")
    };
    private List<string> Decriptions = new List<string>
    {
        "Good, simple filament.",
        "This filament need's better printer",
        "Not set.",
        "I like this type.",
    };

}
