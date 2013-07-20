using System.Linq;
using System.Web.Mvc;
using Fullback.WebHost.Models;

namespace Fullback.WebHost.Controllers
{
    public class TeamController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Statistics(int id = 0)
        {
            var model = new TeamStatisticsModel();

            if (id > 0)
            {
                model = (from t in DataContext.Teams
                         where t.TeamID == id
                         select new TeamStatisticsModel
                             {
                                 Name = t.Name,
                                 TeamID = t.TeamID
                             }).First();
            }

            return View(model);
        }
    }
}