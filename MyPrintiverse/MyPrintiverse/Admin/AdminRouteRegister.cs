using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPrintiverse.Admin.Tests;

namespace MyPrintiverse.Admin
{
	public class AdminRouteRegister : RouteRegister
	{
		public override void RegisterRoutes()
		{
			var routes = new List<Type>()
			{
				typeof(AdminView),
				typeof(AndromedaView),
				typeof(OdysseyView),
				typeof(OrionView)
			};

			Register(routes);
		}
	}
}
