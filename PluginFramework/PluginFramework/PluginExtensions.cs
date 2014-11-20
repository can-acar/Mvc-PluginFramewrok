using PluginFramework.UI;

namespace PluginFramework
{
    public static class PluginExtensions
    {
        public static void Add(this NavigationBuilder builder, Menu menu)
        {
            builder.Add(menu);
        }
    }
}