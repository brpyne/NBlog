using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fullback.Data;

namespace Fullback.WebHost.Controllers
{
    public class EscalationProcedureController : BaseController
    {
        public ActionResult Index()
        {
            IEnumerable<EscalationProcedure> _procs = (from x in DataContext.EscalationProcedures
                                                       select x).AsEnumerable<EscalationProcedure>();

            return View(_procs);
        }

        public ActionResult Details(int id)
        {
            EscalationProcedure _proc = (from x in DataContext.EscalationProcedures
                                         where x.EscalationProcedureID == id
                                         select x).First<EscalationProcedure>();
            return View(_proc);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var model = new EscalationProcedure()
                    {
                        ApplicationID = Int32.Parse(collection.Get("ApplicationID")),
                        Title = collection.Get("Title"),
                        Description = collection.Get("Description"),
                        Impact = Int32.Parse(collection.Get("Impact")),
                        CreatedBy = CurrentUser.CommonId,
                        LastUpdatedBy = CurrentUser.CommonId,
                        CreatedOn = DateTime.Now,
                        LastUpdatedOn = DateTime.Now
                    };

                DataContext.EscalationProcedures.Add(model);
                DataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View();
            }
        }

        public ActionResult Edit(int id)
        {

            var model = (from x in DataContext.EscalationProcedures
                                         where x.EscalationProcedureID == id
                                         select x).First<EscalationProcedure>();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                EscalationProcedure model = (from x in DataContext.EscalationProcedures
                                             where x.EscalationProcedureID == id
                                             select x).First<EscalationProcedure>();

                model.ApplicationID = Int32.Parse(collection.Get("ApplicationID"));
                model.Title = collection.Get("Title");
                model.Description = collection.Get("Description");

                DataContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            EscalationProcedure _proc = (from x in DataContext.EscalationProcedures
                                         where x.EscalationProcedureID == id
                                         select x).First<EscalationProcedure>();
            DataContext.EscalationProcedures.Remove(_proc);
            DataContext.SaveChanges();


            return RedirectToAction("Index");
        }

    }
}
