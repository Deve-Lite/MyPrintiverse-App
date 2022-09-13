

namespace MyPrintiverse;

public abstract class BaseValidator<T> : Validator<T> where T : BaseModel, new()
{
    protected ValidationMode _validatonMode;

    public string Id { get; set; }
    public long CreatedAtTicks { get; set; }
    public long EditedAtTicks { get; set; }

    protected void BaseModelMap(T item)
    {
        item.Id = Id;
        item.CreatedAtTicks = CreatedAtTicks;
        item.EditedAtTicks = EditedAtTicks;
    }

    protected virtual void FillData(T filament)
    {
        Id = filament.Id;
        CreatedAtTicks = filament.CreatedAtTicks;
        EditedAtTicks = filament.EditedAtTicks;
    }
}
