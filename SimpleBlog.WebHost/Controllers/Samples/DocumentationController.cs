using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fullback.WebHost.Controllers
{
    public class DocumentationController : Controller
    {
        public ActionResult FAQ()
        {
            ViewBag.Title = "FAQ (Frequently Asked Questions)";

            return View();
        }

        public ActionResult Guides()
        {
            ViewBag.Title = "Guides";
            ViewBag.Message = "Instructional videos and tutorials for other teams, developers, and team leaders.";

            return View();
        }

        public ActionResult Teams()
        {
            ViewBag.Title = "Teams";
            ViewBag.Description = "Information on each team and the applications they support.";

            return View();
        }
    }
}
