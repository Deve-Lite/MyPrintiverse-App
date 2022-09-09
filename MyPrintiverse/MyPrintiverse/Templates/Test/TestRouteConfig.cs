
namespace MyPrintiverse.Templates.Test;

public class TestRouteConfig : RouteRegister
{
    public override void RegisterRoutes()
    {
        var routes = new List<Type>()
        {
            typeof(TestPage),
        };

        Register(routes);
    }
}
