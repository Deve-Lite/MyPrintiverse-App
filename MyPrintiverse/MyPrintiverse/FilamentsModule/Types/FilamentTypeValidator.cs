﻿
using Plugin.ValidationRules.Interfaces;

namespace MyPrintiverse.FilamentsModule.Types;
public class FilamentTypeValidator : BaseValidator<FilamentType>, IMapperValidator<FilamentType>
{
    public FilamentType Map()
    {
        throw new NotImplementedException("Implement FilamentTypeValidator.");
    }
}