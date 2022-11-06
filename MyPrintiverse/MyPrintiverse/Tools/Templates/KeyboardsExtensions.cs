

namespace MyPrintiverse.Tools.Templates;

public static class KeyboardsExtensions
{
    public static Keyboard Map(Keyboards keyboard) => keyboard switch
    {
        Keyboards.Numeric => Keyboard.Numeric,
        Keyboards.Telephone => Keyboard.Telephone,
        Keyboards.Text => Keyboard.Text,
        Keyboards.Plain => Keyboard.Plain,
        Keyboards.Chat => Keyboard.Chat,
        Keyboards.Email => Keyboard.Email,
        Keyboards.Url => Keyboard.Url,
    };
}
