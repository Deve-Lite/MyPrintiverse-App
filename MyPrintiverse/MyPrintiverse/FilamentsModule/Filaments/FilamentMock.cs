using MyPrintiverse.FilamentsModule.Types;

namespace MyPrintiverse.FilamentsModule.Filaments;

public class FilamentMock : BaseMock<Filament>
{
    FilamentTypeService _filamentTypeService;
    FilamentTypeMock _filamentTypeMock;

    public FilamentMock(FilamentTypeMock filamentTypeMock, FilamentTypeService filamentTypeService)
    {
        _filamentTypeService = filamentTypeService;
        _filamentTypeMock = filamentTypeMock;
    }

    public async Task<Filament> GenerateFilament()
    {
        var filament = new Filament();

        filament.Brand = GetRandomFromList(Brands);
        filament.TypeId = await GetType();
        var color = GetRandomFromList(Colors);
        filament.Color = color.Item1;
        filament.ColorHex = color.Item2;
        filament.Description = GetRandomFromList(Decriptions);
        filament.Diameter = Rand(2.85);

        filament.NozzleTemperature = Rand(190, 250);
        filament.BedTemperature = Rand(50, 80);
        filament.CoolingRate = Rand(0, 100);
        filament.Rating = Rand(1, 5);

        return filament;
    }

    private List<string> Decriptions = new List<string>
    {
        "Very good and cheap filament for testing projects.",
        "Good filament for seling products",
        "Bad filament for everything. Don't buy it again.",
        "Filament of my production, only for testing projects.",
        "This filament makes great impression only when it is printed in good resolution",
        "Not Set."
    };
    private List<string> Brands = new List<string>
    {
        "Devil Design",
        "Debil Design",
        "Prusmaent",
        "3D Filament",
        "Nebula",
        "My Own"
    };
    private List<Tuple<string, string>> Colors = new List<Tuple<string, string>>
    {
        Tuple.Create("Normal Gray", "808080"),
        Tuple.Create("Cyan", "00FFFF"),
        Tuple.Create("Magenta", "FF00FF"),
        Tuple.Create("White", "FFFFFF"),
        Tuple.Create("White Smoke", "f5f5f5"),
        Tuple.Create("Glaxy Gray", "818181")
    };

    private async Task<string> GetType()
    {
        var items = (List<FilamentType>)await _filamentTypeService.GetItemsAsync();

        if (items.Count == 0)
        {
            await _filamentTypeService.AddItemAsync(_filamentTypeMock.GenerateFilamentType());
            items = (List<FilamentType>)await _filamentTypeService.GetItemsAsync();
        }

        int count = items.Count;

        return items[Rand(0, count - 1)].Id;
    }

}
