

namespace MyPrintiverse;

public abstract class BaseValidator<T> where T : BaseModel, new()
{
    protected ValidationMode _validatonMode;

    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime EditedAt { get; set; }

    protected void BaseModelMap(T item)
    {
        item.Id = Id;
        item.CreatedAt = CreatedAt;
        item.EditedAt = EditedAt;
    }

    protected virtual void FillData(T filament)
    {
        Id = filament.Id;
        CreatedAt = filament.CreatedAt;
        EditedAt = filament.EditedAt;
    }
}
