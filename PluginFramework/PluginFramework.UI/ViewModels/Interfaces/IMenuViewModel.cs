using System.Collections.Generic;

namespace PluginFramework.UI.ViewModels.Interfaces
{
    public interface IMenuViewModel
    {
        IEnumerable<Menu> Menu { set; get; } 
    }
}
