using System;
using System.Collections.Generic;

namespace PluginFramework.UI
{
    public class Menu
    {
        public Guid Guid { set; get; }
        public string MenuTitle { get; set; }
        public string MenuName { get; set; }
        public string MenuPageTitle { get; set; }
        public string MenuSlug { get; set; }
        public string MenuAction { get; set; }
        public string MenuIconUrl { get; set; }
        public int MenuAccessLevel { get; set; }
        public int MenuOrder { get; set; }
        public bool IsSubMenu { get; set; }
        public ICollection<Menu> MenuSubs { get; set; }
    }
}
