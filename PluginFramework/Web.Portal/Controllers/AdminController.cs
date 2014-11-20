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
        private readonly IMenuRepository _menuRepository;
        public AdminController(IMenuRepository menu_repository)
        {
            menu_repository.AddMenu(new Menu
            {
                Guid = Guid.NewGuid(),
                MenuAccessLevel = 10,
                MenuAction = "Settings",
                MenuIconUrl = "",
                MenuName = "Demo",
                MenuOrder = 0,
                MenuPageTitle = "Demo Plugin",
                MenuSlug = "demo",
                MenuTitle = "Demo Plugin"
            });

            _menuRepository = menu_repository;
        }


        // GET: Admin
        public ActionResult Index()
        {
            var menuview = new MenuViewModel
            {
                Menu = _menuRepository.AllMenus()
            };

            return View(menuview);
        }
    }
}