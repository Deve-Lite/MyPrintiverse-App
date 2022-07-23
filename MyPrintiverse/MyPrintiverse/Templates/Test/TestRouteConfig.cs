
namespace MyPrintiverse.Templates.Test;

public static class TestRouteConfig
{
    public static void RegisterTestRoutes()
    {
        Routing.RegisterRoute(nameof(TestPage), typeof(TestPage));
    }
}
