using MyPrintiverse.Core.Services.Device;
using System.Linq.Expressions;

namespace MyPrintiverse.FilamentsModule.Spools.Services;
public class SpoolDeviceService : BaseDeviceItemKeyService<Spool>
{
    public SpoolDeviceService() : base(nameof(Spool))
    {
    }

    public override Expression<Func<Spool, bool>> ItemIsMatch(string key) => item => key == item.FilamentId;
}

