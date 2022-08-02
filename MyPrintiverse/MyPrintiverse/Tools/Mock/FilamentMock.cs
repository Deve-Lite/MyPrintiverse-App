using MyPrintiverse.FilamentsModule.Filaments;
using MyPrintiverse.FilamentsModule.Types;

namespace MyPrintiverse.Tools.Mock;

public class FilamentMock : BaseMock<Filament>
{
    FilamentTypeService _filamentTypeService;
    FilamentTypeMock _filamentTypeMock;

    public FilamentMock(FilamentTypeMock filamentTypeMock,FilamentTypeService filamentTypeService)
    {
        _filamentTypeService = filamentTypeService;
        _filamentTypeMock = filamentTypeMock;
    }

    public async Task<Filament> GenerateFilament()
    {
        var filament = new Filament();

        filament.Brand = GetRandomFromList(Brands);
        filament.TypeId = await GetType();
        var color = GetColor();
        filament.Color = color.Item1;
        filament.ColorHex = color.Item2;
        filament.ShortDescription = GetRandomFromList(Decriptions);
        filament.Diameter = 1.75;

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
}
    private Tuple<string, string> GetColor()
    {
        switch (Rand(0, 8))
        {
            case 0:
                return Tuple.Create("Normal Gray", "808080");
            case 1:
                return Tuple.Create("Cyan", "00FFFF");
            case 2:
                return Tuple.Create("Magenta", "FF00FF");
            case 3:
                return Tuple.Create("White", "FFFFFF");
            case 4:
                return Tuple.Create("White Smoke", "f5f5f5");
            default:
                return Tuple.Create("Glaxy Gray", "818181");
        }
    }
    private async Task<string> GetType()
    {
        var items = (List<FilamentType>) await _filamentTypeService.GetItemsAsync();

        if (items.Count == 0)
        {
            await _filamentTypeService.AddItemAsync(_filamentTypeMock.GenerateFilamentType());
            items = (List<FilamentType>) await _filamentTypeService.GetItemsAsync();
        }

        int count = items.Count;

        return items[Rand(0, count-1)].Id;
    }

}
