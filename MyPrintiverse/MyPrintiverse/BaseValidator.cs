

namespace MyPrintiverse;

public abstract class BaseValidator<T> : Validator<T> where T : BaseModel, new()
{
    public string Id { get; set; }
    public long CreatedAtTicks { get; set; }
    public long EditedAtTicks { get; set; }

    /// <summary>
    /// Maps model item to class data
    /// </summary>
    /// <param name="item"></param>
    protected void BaseModelMap(T item)
    {
        item.Id = Id;
        item.CreatedAtTicks = CreatedAtTicks;
        item.EditedAtTicks = EditedAtTicks;
    }

    /// <summary>
    /// Maps given item to class data.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void Map(T item)
    {
        Id = item.Id;
        CreatedAtTicks = item.CreatedAtTicks;
        EditedAtTicks = item.EditedAtTicks;
    }
}
