using PluginFramework.UI;
using PluginFramework.UI.Repositories.Interfaces;

namespace PluginFramework
{
    public class NavigationBuilder
    {
        private readonly IMenuRepository _menuRepository;
        public NavigationBuilder(IMenuRepository menu)
        {
            _menuRepository = menu;
        }

        public virtual void Add(Menu menu)
        {
            _menuRepository.AddMenu(menu);
        }

    }
}