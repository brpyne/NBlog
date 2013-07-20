using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Fullback.WebHost.Extensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString ActionMenuItem(this HtmlHelper htmlHelper, String linkText,
                                                   String actionName, String controllerName)
        {
            var tag = new TagBuilder("li");

            if (htmlHelper.ViewContext.RequestContext
                          .IsCurrentRoute(null, controllerName, actionName))
            {
                tag.AddCssClass("selected");
            }

            tag.InnerHtml = htmlHelper.ActionLink(linkText, actionName, controllerName).ToString();

            return MvcHtmlString.Create(tag.ToString());
        }
    }
}