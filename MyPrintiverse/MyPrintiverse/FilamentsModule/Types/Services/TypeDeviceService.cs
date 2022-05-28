
using MyPrintiverse.Base.Services;

namespace MyPrintiverse.FilamentsModule.Types.Services;

public class TypeDeviceService : BaseDeviceService<Type>
{
    public TypeDeviceService()
    {
        dbName = $"{nameof(Type)}.db";
    }
}

