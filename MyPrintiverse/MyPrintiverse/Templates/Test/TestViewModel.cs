

namespace MyPrintiverse.Templates.Test;

public class TestViewModel : BaseViewModel
{
    bool boolValue;
    public bool BoolValue { get => boolValue; set => SetProperty(ref boolValue, value, test); }


    public void test()
    {
        Console.WriteLine("Pressed");
    }

}
