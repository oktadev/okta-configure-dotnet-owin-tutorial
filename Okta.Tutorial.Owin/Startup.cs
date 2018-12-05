using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Okta.AspNet;
using Owin;
using System.Collections.Generic;
using System.Configuration;

namespace Okta.Tutorial.Owin
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			SetCookieAuthenticationAsDefault(app);
			AddOktaAuthenticationMiddleware(app);
		}

		private void SetCookieAuthenticationAsDefault(IAppBuilder app)
		{
			app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
			app.UseCookieAuthentication(new CookieAuthenticationOptions());
		}

		private void AddOktaAuthenticationMiddleware(IAppBuilder app)
		{
			app.UseOktaMvc(new OktaMvcOptions()
			{
				OktaDomain = ConfigurationManager.AppSettings["okta:OktaDomain"],
				ClientId = ConfigurationManager.AppSettings["okta:ClientId"],
				ClientSecret = ConfigurationManager.AppSettings["okta:ClientSecret"],
				RedirectUri = ConfigurationManager.AppSettings["okta:RedirectUri"],
				PostLogoutRedirectUri = ConfigurationManager.AppSettings["okta:PostLogoutRedirectUri"],
				GetClaimsFromUserInfoEndpoint = true,
				Scope = new List<string> { "openid", "profile", "email" },
			});
		}
	}
}