using System;
using System.Web.Mvc;
using PluginFramework;
using PluginFramework.UI;
using PluginFramework.UI.Repositories.Interfaces;
using PluginFramework.UI.ViewModels;

namespace Web.Portal.Demo.Module.Controllers
{
    public class AdminController : PluginController
    {
        //public AdminController()
        //{
        //    var repo = GetServices<IMenuRepository>();
        //    var repos = GetServices<IMenuRepository>();
        //}
        private readonly IMenuRepository _menuRepository;
        public AdminController(IMenuRepository menu_repository)
        {
            menu_repository.AddMenu(new Menu
            {
                Guid = new Guid(),
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