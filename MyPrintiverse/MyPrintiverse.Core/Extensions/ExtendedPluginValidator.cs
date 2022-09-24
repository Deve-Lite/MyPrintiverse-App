

using Plugin.ValidationRules.Extensions;
using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.Core.Extensions;

public static class ExtendedValidator 
{
    public static ExtendedValidatable<TModel> Build<TModel>()
    {
        return new ExtendedValidatable<TModel>();
    }

    public static ExtendedValidatable<TModel> WithRule<TModel>(this ExtendedValidatable<TModel> validatable, IValidationRule<TModel> validation, string errorMessage = "")
    {
        if (errorMessage != "")
            validation.WithMessage(errorMessage);

        validatable.Validations.Add(validation);

        return validatable;
    }

    public static ExtendedValidatable<TModel> WithRule<TModel>(this ExtendedValidatable<TModel> validatable, params IValidationRule<TModel>[] validations)
    {
        validatable.Validations.AddRange(validations);
        return validatable;
    }
}
