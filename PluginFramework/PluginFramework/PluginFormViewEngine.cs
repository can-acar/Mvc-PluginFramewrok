using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PluginFramework
{
    public class PluginFormViewEngine:RazorViewEngine
    {
        public PluginFormViewEngine(string plugin_path, IEnumerable<IPlugin> plugins, string default_master):base()
        {
            IList<string> masterLocationFormats = new List<string> { 
                "~/Views/{1}/{0}.master",
                "~/Views/Shared/{0}.master" };


            AreaMasterLocationFormats = new[] { 
                "~/Areas/{2}/Views/{1}/{0}.master",
                "~/Areas/{2}/Views/Shared/{0}.master" };

            IList<string> viewLocationFormats = new List<string> { 
                "~/Views/{1}/{0}.aspx",
                "~/Views/{1}/{0}.ascx",
                "~/Views/Shared/{0}.aspx",
                "~/Views/Shared/{0}.ascx" };

            AreaViewLocationFormats = new[] { 
                "~/Areas/{2}/Views/{1}/{0}.aspx",
                "~/Areas/{2}/Views/{1}/{0}.ascx",
                "~/Areas/{2}/Views/Shared/{0}.aspx",
                "~/Areas/{2}/Views/Shared/{0}.ascx" };

            // register all forms (non-razor) view locations for each plugin (e.g. web\plugin\%assemblyname%\views)
            foreach (var plugin in plugins)
            {
                masterLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/{1}/{0}.master");
                masterLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/Shared/{1}/{0}.master");

                viewLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/{1}/{0}.aspx");
                viewLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/{1}/{0}.ascx");
                viewLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/Shared/{1}/{0}.aspx");
                viewLocationFormats.Add("~/Plugins/" + plugin.PluginName + "/Views/Shared/{1}/{0}.ascx");
            }

            MasterLocationFormats = masterLocationFormats.ToArray();
            ViewLocationFormats = viewLocationFormats.ToArray();
            PartialViewLocationFormats = ViewLocationFormats;
            AreaPartialViewLocationFormats = AreaViewLocationFormats;
        }
    }
}
