
using MyPrintiverse.FilamentsModule.Types;

namespace MyPrintiverse.Tools.Mock;

public class FilamentTypeMock : BaseMock<FilamentType>
{
    public FilamentType GenerateFilamentType()
    {
        var item = new FilamentType();

        item.Density = Rand(3);
        var name = GetName();
        item.FullName = name.Item1;
        item.ShortName = name.Item2;

        item.MaxServiceTempearature = Rand(150);
        item.BedTemperatureRange = $"{Rand(40, 50)}-{Rand(50, 90)}";
        item.NozzleTemperatureRange = $"{Rand(190, 210)}-{Rand(210, 230)}";
        item.CoolingRange = $"{Rand(0, 50)}-{Rand(50, 100)}";
        item.Density = Rand(1.5);
        item.IsFlexible = Rand();
        item.IsBio = Rand();
        item.IsUVResistant = Rand();
        item.IsFoodFriendly = Rand();
        item.IsHeatedBedRequired = Rand();

        return item;
    }

    private Tuple<string, string> GetName()
    {
        switch(Rand(0, 5))
        {
            case 0: return Tuple.Create("PLA", "Polylactic acid");
            case 1: return Tuple.Create("PETG", "Polyethylene terephthalate glycol");
            case 2: return Tuple.Create("ABS", "Acrylonitrile butadiene styrene");
            case 3: return Tuple.Create("ASA", "Acrylonitrile Styrene Acrylate");
            case 4: return Tuple.Create("FLEX40", "Flexible");
            default: return Tuple.Create("OWN", "Random mix");
        }
    }

}
