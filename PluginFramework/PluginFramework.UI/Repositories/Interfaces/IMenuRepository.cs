using System;
using System.Collections.Generic;

namespace PluginFramework.UI.Repositories.Interfaces
{
    public interface IMenuRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item" type="Menu"></param>
        /// <returns></returns>
        Menu AddMenu(Menu item);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid" type="Guid"></param>
        /// <returns></returns>
        Menu GetMenu(Guid guid);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Menu> AllMenus();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        ICollection<Menu> AddSubMenu(Menu menu);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        ICollection<Menu> AddSubMenus(List<Menu> list);
    }
}
