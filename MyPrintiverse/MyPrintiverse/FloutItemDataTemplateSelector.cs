namespace MyPrintiverse;

public class FloutItemDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate FlyoutItem { get; set; }
    public DataTemplate MenuItem { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var flyoutObject = (FlyoutItem)item;

        return (flyoutObject.Icon == null || flyoutObject.Icon.IsEmpty) ? MenuItem : FlyoutItem;
    }
}
