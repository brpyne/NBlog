using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Fullback.WebHost.Extensions
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper,
                                             string linkText,
                                             string actionName,
                                             string controllerName)
        {
            return MenuLink(htmlHelper, linkText, actionName, controllerName, string.Empty);
        }

        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper,
                                             string linkText,
                                             string actionName,
                                             string controllerName,
                                             object routingOptions)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            if (actionName == currentAction && controllerName == currentController)
            {
                return htmlHelper.ActionLink(linkText,
                                             actionName,
                                             routingOptions,
                                             new {@class = "selected"});
            }

            return htmlHelper.ActionLink(linkText,
                                         actionName,
                                         controllerName,
                                         routingOptions,
                                         new {@class = ""});
        }


        // Need to break this up and insert entire nav

        public static string NavItemClass(this HtmlHelper htmlHelper,
                                          bool isDropdown,
                                          string controllerName)
        {
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            string cssClass = isDropdown ? "dropdown" : "nav-item";
            if (currentController == controllerName)
                cssClass += " active";

            return cssClass;
        }

        public static MvcHtmlString NavItemLink(this HtmlHelper htmlHelper,
                                                string iconClass,
                                                string action,
                                                string actionName,
                                                string controllerName)
        {
            return DropdownLink(htmlHelper,
                                string.Empty,
                                iconClass,
                                string.Empty,
                                action,
                                actionName,
                                controllerName);
        }

        public static MvcHtmlString DropdownLink(this HtmlHelper htmlHelper,
                                                 string linkText,
                                                 string iconClass,
                                                 string actionName,
                                                 string controllerName)
        {
            return DropdownLink(htmlHelper,
                                linkText,
                                iconClass,
                                "caret",
                                string.Empty,
                                actionName,
                                controllerName);
        }

        public static MvcHtmlString DropdownLink(this HtmlHelper htmlHelper,
                                                 string linkText,
                                                 string iconPrefix,
                                                 string iconSuffix,
                                                 string redirectToAction,
                                                 string actionName,
                                                 string controllerName)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            string output = string.Empty;

            //var listItemBuilder = new TagBuilder("li");
            var builder = new TagBuilder("a");
            var iconClassBuilder = new TagBuilder("i");
            var iconSuffixClassBuilder = new TagBuilder("b");
            var spanClassbuilder = new TagBuilder("span");

            //listItemBuilder.Attributes.Add("class", isActiveClassCSS);

            string href = !string.IsNullOrEmpty(redirectToAction) ? redirectToAction : "javascript:;";
            builder.Attributes.Add("href", href);
            builder.Attributes.Add("data-toggle", "dropdown");
            builder.Attributes.Add("class", "dropdown-toggle");

            iconClassBuilder.Attributes.Add("class", iconPrefix);
            iconSuffixClassBuilder.Attributes.Add("class", iconSuffix);
            spanClassbuilder.SetInnerText(linkText);

            builder.InnerHtml = iconClassBuilder.ToString(TagRenderMode.Normal) +
                                spanClassbuilder.ToString(TagRenderMode.Normal) +
                                iconSuffixClassBuilder.ToString(TagRenderMode.Normal);

            //listItemBuilder.InnerHtml = builder.ToString(TagRenderMode.Normal);

            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }
    }
}