

using Plugin.ValidationRules;

namespace MyPrintiverse.Core.Extensions;

public partial class ExtendedValidatable<T> : Validatable<T>
{
    [RelayCommand]
    public void ExtendedValidate() => Validate();
}
