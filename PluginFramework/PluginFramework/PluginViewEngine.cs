using System.Collections.Generic;
using System.Web.Mvc;

namespace PluginFramework
{
    public class PluginViewEngine : RazorViewEngine
    {
        public PluginViewEngine(string plugin_path, IEnumerable<IPlugin> plugins, string default_razor_master)
            : base()
        {
            AreaViewLocationFormats = new[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };
            AreaMasterLocationFormats = new[] { 
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml" };

            AreaPartialViewLocationFormats = new[] { 
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml" };

            var partialViewLocationFormats = new List<string> { 
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml" };

            var masterLocationFormats = new List<string> { 
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml" };

            foreach (var plugin in plugins)
            {
                masterLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/{1}/{0}.cshtml");
                masterLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/{1}/{0}.vbhtml");
                masterLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/Shared/{1}/{0}.cshtml");
                masterLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/Shared/{1}/{0}.vbhtml");

                partialViewLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/{1}/{0}.cshtml");
                partialViewLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/{1}/{0}.vbhtml");
                partialViewLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/Shared/{1}/{0}.cshtml");
                partialViewLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/Shared/{1}/{0}.vbhtml");



            }

            ViewLocationFormats = partialViewLocationFormats.ToArray();
            MasterLocationFormats = masterLocationFormats.ToArray();
            PartialViewLocationFormats = partialViewLocationFormats.ToArray();
        }
    }

}
