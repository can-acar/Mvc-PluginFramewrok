using System;
using System.Web.Mvc;
using PluginFramework.UI;
using PluginFramework.UI.Repositories.Interfaces;
using PluginFramework.UI.ViewModels;

namespace Web.Portal.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public AdminController(IMenuRepository repository)
        {
            var menuRepository = repository;
        }
        public ActionResult Index()
        {

            return View();
        }
    }
}