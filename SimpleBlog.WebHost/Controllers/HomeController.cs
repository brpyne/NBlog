using System;
using System.Web.Mvc;
using Fullback.ServiceInterface;
using Fullback.ServiceInterface.Services;
using Fullback.ServiceModel.Models;
using Fullback.ServiceModel.Operations;
using Fullback.WebHost.Models;
using ServiceStack.Mvc;
using ServiceStack.WebHost.Endpoints;

namespace Fullback.WebHost.Controllers
{
    public class HomeController : ServiceStackController
    {
        public ActionResult Index()
        {
            var service = AppHostBase.Resolve<TeamsService>();

            var team = (Team) service.Get(new GetTeam {Id = 12});
            ViewBag.Title = team.ADGroup;


            ViewBag.Message = "You are modifying the Loans Platform team.";

            var model = new HomeDashboardModel();
            var mailItems = new Fullback.ServiceInterface.StatisticsService();

            model.TodaysPerformance.Add(new Statistic
                {
                    Value = mailItems.AlertCount(DateTime.Now.Day),
                    Name = "Loans Platform Alert Count Total"
                });
            model.TodaysPerformance.Add(new Statistic
                {
                    Value = mailItems.AlertCount(DateTime.Now.Day, new Data.Team {TeamID = 13}),
                    Name = "Carbon's Alert Count Total"
                });
            model.TodaysPerformance.Add(new Statistic
                {
                    Value = mailItems.AlertCount(DateTime.Now.Day, new Data.Team {TeamID = 12}),
                    Name = "Centro's Alerts Count Total"
                });
            model.TodaysPerformance.Add(new Statistic
                {
                    Value = mailItems.AlertCount(DateTime.Now.Day, new Data.Team {TeamID = 10}),
                    Name = "Skynet's Alerts Count Total"
                });

            return View(model);
        }
    }
}