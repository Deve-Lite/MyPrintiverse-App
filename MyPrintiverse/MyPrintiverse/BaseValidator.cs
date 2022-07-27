

namespace MyPrintiverse;

public class BaseValidator<T> where T : BaseModel, new()
{
    public Validatable<string> Id { get; set; }
    public Validatable<DateTime> CreatedAt { get; set; }
    public Validatable<DateTime> EditedAt { get; set; }

    public void BaseModelMap(T item)
    {
        item.Id = Id.Value;
        item.CreatedAt = CreatedAt.Value;
        item.EditedAt = EditedAt.Value;
    }
}
