using System.Web;
using System.Web.Optimization;

namespace Fullback.WebHost
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            // Add back the default ignore list rules 
            //sans the ones which affect minified files and debug mode
            bundles.IgnoreList.Ignore("*.intellisense.js");
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.0.2.min.js",
                        "~/Scripts/jquery-ui-1.10.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery.ui.touch-punch.min.js",
                        "~/Scripts/bootstrap*",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/Theme.js",
                        "~/Scripts/texttransition.js"));

            bundles.Add(new ScriptBundle("~/bundles/demos").Include(
                        "~/Scripts/Charts.js",
                        "~/Scripts/demos/charts/line.js",
                        "~/Scripts/demos/charts/donut.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/libs/modernizr-2.5.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                        "~/Scripts/fullcalendar.min.js"));


            bundles.Add(new StyleBundle("~/Content/template").Include(
                "~/Content/font-awesome.css",
                "~/Content/ui-lightness/jquery-ui-1.8.21.custom.css",
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-responsive.css",
                "~/Content/application.css",
                "~/Content/dashboard.css",
                "~/Content/text-rotator.css"));


            bundles.Add(new StyleBundle("~/Content/calendar").Include(
                "~/Content/calendar/fullcalendar.css"));

        }
    }
}