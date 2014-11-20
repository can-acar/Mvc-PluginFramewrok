using System;
using System.Collections.Generic;
using System.Linq;


namespace PluginFramework.UI.Repositories
{
    using Interfaces;
    public class MenuRepository : IMenuRepository
    {


        private readonly IList<Menu> _dataListMenus = new List<Menu>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Menu AddMenu(Menu item)
        {
            item.Guid = new Guid();
            // if exists menu
            var isExistMenu = _dataListMenus.FirstOrDefault(x => x.MenuSlug == item.MenuSlug);
            if (isExistMenu != null)
            {
                isExistMenu.MenuSubs.Add(item);
                return isExistMenu;
            }

            _dataListMenus.Add(item);
            return item;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Menu GetMenu(Guid guid)
        {
            return _dataListMenus.FirstOrDefault(x => x.Guid == guid);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Menu> AllMenus()
        {
            return _dataListMenus;
        }

        /// <summary>
        /// AddSubMenu(Menu menu)
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public ICollection<Menu> AddSubMenu(Menu menu)
        {
            var item = new List<Menu> { menu };
            return item;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public ICollection<Menu> AddSubMenus(List<Menu> list)
        {
            var item = new List<Menu>();
            item.AddRange(list);
            return item;
        }
    }
}
