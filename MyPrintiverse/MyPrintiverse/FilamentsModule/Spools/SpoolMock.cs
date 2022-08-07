namespace MyPrintiverse.FilamentsModule.Spools;

public class SpoolMock : BaseMock<Spool>
{
    public Spool GenerateSpool(string filamentId)
    {
        var item = new Spool();

        item.FilamentId = filamentId;
        item.IsSample = Rand();
        item.StandardWeight = Rand(1);
        double weight = Rand(1);
        if (Rand(-1, 2)>0)
            item.AvaliableWeight = weight > item.StandardWeight ? item.StandardWeight : weight;
        else
            item.AvaliableWeight = 0;
        item.IsFinished = item.AvaliableWeight == 0;
        item.Description = GetRandomFromList(Decriptions);



        return item;
    }

    private List<string> Decriptions = new List<string>
    {
        "Cool filament.",
        "Use this roll only to Łukasz Kolber items production.",
        "Use this roll only to Foreginer items production.",
        "Use this roll only to Kamil Pasternak items production.",
        "Use this roll only to samples.",
        "Not Set."
    };
}
