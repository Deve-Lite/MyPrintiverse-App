
using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.FilamentsModule.Filaments;

public class FilamentRule : IValidationRule<Filament>
{
    public FilamentRule(ValidationMode validationMode)
    {
        // Tutaj wazne jak graficye to rozwiazą 
        // jezeli ma byc jedno pole z errorem to jest git,
        // plusy:
        // - potrzebna tylko 1 metoda validacji
        // minusy:
        // - validacja może brzydko wychodzić 

        // jezeli pod kazdym entry ma byc pole erroru to złe podejscie -> w przykładach jest ValidateUser -> inny interfeace i trzeba go użyć
        // plusy:
        // - problem wyswietlany zaraz pod polem z problemem -> szybkie znajdywanie problemu 
        // - ładniejszy wygląd validacji 
        // - możliwośc validacji po 1 polu
        // minusy:
        // - potrzebna tylko x metod validacji
    }

    public string ValidationMessage { get; set; }

    public bool Check(Filament filament)
    {
        if (filament == null) 
            return false;

        if (string.IsNullOrEmpty(filament.ColorName) || 3 > filament.ColorName.Length || filament.ColorName.Length > 20) 
        {
            if (string.IsNullOrEmpty(filament.ColorName))
            {
                ValidationMessage = "";
                return false;
            }

            ValidationMessage = "";
            return false;
        }
        else if (filament == null)
        {
            return false;
        }

        return true;
    }
}
