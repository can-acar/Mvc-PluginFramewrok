using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PluginFramework.UI;

namespace PluginFramework
{
    public static class PluginExtensions
    {
        public static void Add(this NavigationBuilder builder, Menu menu)
        {
            builder.Add(menu);
        }
    }

    public static class HtmlRequestHelper
    {
        public static string Id(this HtmlHelper html_helper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            if (routeValues.ContainsKey("id"))
                return (string)routeValues["id"];
            else if (HttpContext.Current.Request.QueryString.AllKeys.Contains("id"))
                return HttpContext.Current.Request.QueryString["id"];

            return string.Empty;
        }

        public static string Controller(this HtmlHelper html_helper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            if (routeValues.ContainsKey("controller"))
                return (string)routeValues["controller"];

            return string.Empty;
        }

        public static string Action(this HtmlHelper html_helper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            if (routeValues.ContainsKey("action"))
                return (string)routeValues["action"];

            return string.Empty;
        }

    }


    public static class StringHelper
    {
        public static string UcFirst(this string s)
        {
            // Check for empty string.
            if (String.IsNullOrEmpty(s))
            {
                return String.Empty;
            }
            // Return char and concat substring.
            return Char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}