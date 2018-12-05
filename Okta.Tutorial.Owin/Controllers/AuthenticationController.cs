using Microsoft.Owin.Security.Cookies;
using Okta.AspNet;
using System.Web;
using System.Web.Mvc;

namespace Okta.Tutorial.Owin.Controllers
{
	public class AuthenticationController : Controller
	{
		public ActionResult SignIn()
		{
			if (!HttpContext.User.Identity.IsAuthenticated)
			{
				HttpContext.GetOwinContext().Authentication.Challenge(
					OktaDefaults.MvcAuthenticationType);
				return new HttpUnauthorizedResult();
			}

			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public ActionResult SignOut()
		{
			if (HttpContext.User.Identity.IsAuthenticated)
			{
				HttpContext.GetOwinContext().Authentication.SignOut(
					CookieAuthenticationDefaults.AuthenticationType,
					OktaDefaults.MvcAuthenticationType);
			}

			return RedirectToAction("Index", "Home");
		}

		public ActionResult PostSignOut()
		{
			return RedirectToAction("Index", "Home");
		}
	}
}