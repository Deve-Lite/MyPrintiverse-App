

namespace MyPrintiverse;

public abstract class BaseValidator<T> where T : BaseModel, new()
{
    protected ValidationMode _validatonMode;

    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime EditedAt { get; set; }

    public void BaseModelMap(T item)
    {
        item.Id = Id;
        item.CreatedAt = CreatedAt;
        item.EditedAt = EditedAt;
    }
}
