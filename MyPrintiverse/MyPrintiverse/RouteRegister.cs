using MyPrintiverse.Core.Collections;

namespace MyPrintiverse
{
	public abstract class RouteRegister
	{
		public void Register(IEnumerable<Type> routes)
		{
			routes.ForEach(route =>
			{
				Routing.RegisterRoute(route.Name, route);
			});
		}

		public abstract void RegisterRoutes();
	}
}
