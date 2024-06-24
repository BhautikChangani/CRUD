using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Kendo.Mvc.Examples.Models
{
    public static class ScriptGroups
    {
        private static string jQueryPath
        {
            get {
                return string.Format(
                    "//code.jquery.com/jquery-{0}.min.js",
                    ConfigurationManager.AppSettings["JQUERY_VERSION"]
                );
            }
        }

        public static IList<string> All = new string[]
        {
            jQueryPath,
            "kendo.all.min.js",
            "kendo.aspnetmvc.min.js",
            "kendo.timezones.min.js"
        };
    }
}
