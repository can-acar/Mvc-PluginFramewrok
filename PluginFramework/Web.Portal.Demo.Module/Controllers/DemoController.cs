using System.Web.Mvc;
using PluginFramework;

namespace Web.Portal.Demo.Module.Controllers
{
    public class DemoController : PluginController
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }
    }
}