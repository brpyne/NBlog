using System.Web;
using System.Web.Mvc;

namespace Fullback.WebHost.Auth
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return UserManager.GetCurrentUser(HttpContext.Current.Session) != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //Logger.LogWriter.Audit("Unauthorized", new { Url = filterContext.RequestContext.HttpContext.Request.RawUrl });
            filterContext.Result = new RedirectResult("/Account/Login");
        }
    }
}