using MyPrintiverse.FilamentsModule.Spools;

namespace MyPrintiverse.FilamentsModule.Filaments;


public class SpoolCollectionDataTemplateSelector : DataTemplateSelector
{

    public DataTemplate FinishedTemplate { get; set; }
    public DataTemplate NotOnSpoolTemplate { get; set; }
    public DataTemplate GoodStatusTemplate { get; set; }
    public DataTemplate MediumStatusTemplate { get; set; }
    public DataTemplate SmallStatusTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var castedItem = (Spool)item;

        if (!castedItem.IsOnSpool)
            return NotOnSpoolTemplate;

        if (castedItem.IsFinished)
            return FinishedTemplate;

        if (castedItem.AvaliableWeight >= 0.8 * castedItem.StandardWeight)
            return GoodStatusTemplate;

        if (castedItem.AvaliableWeight >= 0.2 * castedItem.StandardWeight)
            return MediumStatusTemplate;

        return SmallStatusTemplate;
    }
}
