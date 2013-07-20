using System;
using System.Linq;
using System.Web.Mvc;
using Fullback.Data;
using Fullback.WebHost.Auth;
using Fullback.WebHost.Models;
using Rock.Framework.Logging;
using ServiceStack.Mvc;
using Logger = Fullback.WebHost.Lib.Logger;

namespace Fullback.WebHost.Controllers
{
    public class BaseController : ServiceStackController
    {
        public FullBackEntities DataContext { get; set; }
        private TeamMember _teamMember;
        private User _user;

        protected virtual User CurrentUser
        {
            get
            {
                _user = (User) Session["currentUser"];
                return _user;
            }
        }

        protected virtual TeamMember CurrentTeamMember
        {
            get
            {
                try
                {
                    _teamMember = (from tm in DataContext.TeamMembers
                                   where tm.CommonId == CurrentUser.CommonId
                                   select tm).First<TeamMember>();
                }
                catch (Exception ex)
                {
                    if (Logger.LogWriter.IsWarnEnabled)
                    {
                        var entry = new LogEntry("Current Team Member Requested But Not Found");
                        entry.ExtendedProperties.Add("Current User Common ID", CurrentUser.CommonId.ToString());
                        Logger.LogWriter.Warn(entry);
                    }
                }

                return _teamMember;
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            ViewBag.TeamMember = CurrentUser;
            if (Logger.LogWriter.IsDebugEnabled && CurrentUser != null)
                Logger.LogWriter.Debug("Action: " + filterContext.Controller + " by User: " + CurrentUser.DisplayName);
        }

        protected override void OnException(ExceptionContext exContext)
        {
            if (Logger.LogWriter.IsErrorEnabled)
                Logger.LogWriter.Error(String.Format("Exception /{0}/{1}",
                                                      exContext.RouteData.RouteHandler,
                                                      exContext.RouteData.Route),
                                        exContext.Exception);
        }

        protected override void Dispose(bool disposing)
        {
            if (DataContext != null)
            {
                DataContext.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}