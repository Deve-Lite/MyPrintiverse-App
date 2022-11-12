

using MyPrintiverse.Tools.Templates;

namespace MyPrintiverse.Templates.Inputs;

public interface IValidatableKeyboard<T>
{
    public static readonly BindableProperty KeyboardTypeProperty = BindableProperty.Create(nameof(KeyboardType), typeof(Keyboards), typeof(T), Keyboards.Default, propertyChanged: SetKeyboard);
    public Keyboards KeyboardType { get; set; }


    public static readonly BindableProperty KeyboardFlagProperty = BindableProperty.Create(nameof(KeyboardFlag), typeof(KeyboardFlags), typeof(T), KeyboardFlags.None, propertyChanged: SetKeyboard);
    public KeyboardFlags KeyboardFlag { get; set; }

    private static void SetKeyboard(BindableObject bindable, object oldValue, object newValue) { }
}
