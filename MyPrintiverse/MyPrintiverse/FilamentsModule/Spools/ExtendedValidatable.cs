

namespace MyPrintiverse.FilamentsModule.Spools;

public partial class ExtendedValidatable<T> : Validatable<T>
{
    [RelayCommand]
    public void ExtendedValidate() => Validate();
}
