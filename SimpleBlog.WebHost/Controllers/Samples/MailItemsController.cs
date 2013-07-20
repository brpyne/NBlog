using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Fullback.Data;
using Fullback.WebHost.Models;
using Fullback.WebHost.Models.Charts;

namespace Fullback.WebHost.Controllers
{
    public class MailItemsController : BaseController
    {
        public ActionResult Index(int page=1)
        {
            return Index(page, 10);
        }

        public ActionResult Index(int page, int pageSize)
        {
            var model = new MailItemModel();

            return View(model);
        }

    }
}