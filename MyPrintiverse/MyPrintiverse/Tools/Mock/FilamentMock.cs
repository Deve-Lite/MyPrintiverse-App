

using MongoDB.Bson;
using MyPrintiverse.FilamentsModule.Filaments;

namespace MyPrintiverse.Tools.Mock;

public class FilamentMock
{
    public static Filament GenerateFilament()
    {
        var filament = new Filament();
        filament.Id = ObjectId.GenerateNewId().ToString();
        filament.EditedAt = DateTime.Now;
        filament.CreatedAt = DateTime.Now;

        filament.Brand = GetBrand();
        filament.Color = GetColorName();
        filament.ColorHex = GetColorHex();
        filament.ShortDescription = GetDescription();
        filament.Diameter = 1.75;

        return filament;
    }

    private static int randint(int min, int max) => new Random().Next(min, max);
       
    

    private static string GetDescription()
    {
        switch (randint(0, 5))
        {
            case 0:
                return "Very good and cheap filament for testing projects.";
            case 1:
                return "Good filament for seling products";
            case 2:
                return "Bad filament for everything. Don't buy it again.";
            case 3:
                return "Filament of my production, only for testing projects.";
            case 4:
                return "This filament makes great impression only when it is printed in good resolution";
            default:
                return "Not Set.";
        }
    }

    private static string GetBrand()
    {
        switch (randint(0, 5))
        {
            case 0:
                return "Devil Design";
            case 1:
                return "Debil Design";
            case 2:
                return "Prusmaent";
            case 3:
                return "3D Filament";
            case 4:
                return "Nebula";
            default:
                return "My Own";
        }
    }

    private static string GetColorHex()
    {
        switch (randint(0, 5))
        {
            case 0:
                return "#FF7788";
            case 1:
                return "#77FF88";
            case 2:
                return "#D3D3D3";
            case 3:
                return "#3D3D3D";
            case 4:
                return "#FFFFFF";
            default:
                return "#6FF5F7";
        }
    }

    private static string GetColorName()
    {
        switch (randint(0, 5))
        {
            case 0:
                return "Flex red";
            case 1:
                return "Carbon root";
            case 2:
                return "Light Green";
            case 3:
                return "Shiny gray";
            case 4:
                return "Black";
            default:
                return "Dumb red";
        }
    }

}
