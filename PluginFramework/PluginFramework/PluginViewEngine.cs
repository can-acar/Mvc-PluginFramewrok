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

            //This property contains the locations where the view engine will search to find a partial view in an area-enabled application.
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

            // register all razor view locations for each plugin (e.g. web\plugin\%assemblyname%\views)
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

            // This property contains the locations where the view engine will search to find a view.
            ViewLocationFormats = partialViewLocationFormats.ToArray();
            // This property contains the locations where the view engine will search to find a master view.
            MasterLocationFormats = masterLocationFormats.ToArray();
            // This property contains the locations where the view engine will search to find a partial view.
            PartialViewLocationFormats = partialViewLocationFormats.ToArray();
        }
    }

}
