using System.Web;
using System.Web.Mvc;

namespace Okta.Tutorial.Owin
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
