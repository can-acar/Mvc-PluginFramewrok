using System.Web.Mvc;
using PluginFramework;

namespace Web.Portal.Demo.Module.Controllers
{
    public class HomeController : PluginController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}