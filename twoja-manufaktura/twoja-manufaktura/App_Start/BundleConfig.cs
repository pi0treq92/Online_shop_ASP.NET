using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace twoja_manufaktura.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquerymobile")
                .Include("~/Scripts/jquery-{version}.js"));
            //Wszystkie skrypty jquery maja trafić do jednej skompresowanej paczki
            bundles.Add(new StyleBundle("~/Content/themes/base/css")
                .Include("~/Content/themes/base/core.css",
                "~/Content/themes/base/autocomplete.css",
                "~/Content/themes/base/theme.css",
                "~/Content/themes/base/menu.css"));
        }
    }
}