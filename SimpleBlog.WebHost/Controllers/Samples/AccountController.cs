using System.Web.Mvc;
using Fullback.WebHost.Lib;
using Fullback.WebHost.Models;
using Fullback.ServiceInterface;

namespace Fullback.WebHost.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            var userLogin = new UserLoginModel {Username = CurrentUser.UserName};

            return View(userLogin);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AutoLogin()
        {
            //if (!IsGuest)
            return RedirectToAction("Index", "Home");

            ViewBag.Message = "Auto Login Failed";

            var m = new UserLoginModel();
            return View("Login", m);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserLoginModel model)
        {
            if (Logger.LogWriter.IsDebugEnabled)
                Logger.LogWriter.Debug("Account / Login POST");

            if (ModelState.IsValid)
            {
                if (Logger.LogWriter.IsDebugEnabled)
                    Logger.LogWriter.Debug("Account / Login Valid Model");

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "The CurrentUser name or password provided is incorrect.");

            return View(model);
        }

        public ActionResult Logout()
        {
            if (Logger.LogWriter.IsDebugEnabled)
                Logger.LogWriter.Debug("User Logged Out");

            return View("Login");
        }
    }
}