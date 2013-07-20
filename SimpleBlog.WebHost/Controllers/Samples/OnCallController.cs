using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Net.Mail;
using System.Web.Mail;


namespace Fullback.WebHost.Controllers
{
    public class OnCallController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            ViewBag.Title = "On Call Schedule";
            ViewBag.Description = "Loans Platform / Centro";

            return View();
        }

        public ActionResult CurrentOnCall()
        {
            ViewBag.currentOnCall = CurrentUser.FirstName + " " + CurrentUser.LastName;

            return View();
        }


        public ActionResult btnSendTeamEmailCurrent_Click()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To = "levrubel@quickenloans.com";
                mail.From = "levrubel@quickenloans.com";
                mail.Subject = "current on call person is: " + CurrentUser.FirstName + " " + CurrentUser.LastName;
                mail.Body = "current on call person is: " + CurrentUser.FirstName + " " + CurrentUser.LastName;
                SmtpMail.SmtpServer = "smtp";  //your real server goes here
                SmtpMail.Send(mail);

               return View("Schedule");
            }
            catch (Exception ex)
            {
             Response.Write(ex.Message);
             return View("Schedule");
            }
        }

        public ActionResult btnSendTeamEmailCancel_Click()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To = "levrubel@quickenloans.com";
                mail.From = "levrubel@quickenloans.com";
                mail.Subject = CurrentUser.FirstName.ToString() + " " + CurrentUser.LastName.ToString() + ":" + "Is NOT on call";
                mail.Body = CurrentUser.FirstName.ToString() + " " + CurrentUser.LastName.ToString() +  "Is NOT on call";
                SmtpMail.SmtpServer = "smtp";  //your real server goes here
                SmtpMail.Send(mail);

                return View("Schedule");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return View("Schedule");
            }
        }
    }
}
