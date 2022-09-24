
namespace MyPrintiverse.Core.Utilities;

/// <summary>
/// Class task is to save reference because ref fields are not avaliable in class
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class Ref<T>
{
    private readonly Func<T> getter;
    private readonly Action<T> setter;
    public Ref(Func<T> getter, Action<T> setter)
    {
        this.getter = getter;
        this.setter = setter;
    }
    public T Value { get => getter(); set => setter(value); }
}
