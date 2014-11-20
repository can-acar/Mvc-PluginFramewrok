using System.Collections.Generic;
namespace PluginFramework.UI.ViewModels
{
    using Interfaces;

    public class MenuViewModel : IMenuViewModel
    {
        public virtual IEnumerable<Menu> Menu { set; get; }

    }
}
