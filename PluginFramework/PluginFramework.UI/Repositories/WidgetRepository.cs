using System;
using System.Collections.Generic;
using System.Linq;


namespace PluginFramework.UI.Repositories
{
    using Interfaces;
    public class WidgetRepository : IWidgetRepository
    {

        public IList<UI.Widget> Widgets { get; private set; }


        public WidgetRepository()
        {
            Widgets = new List<UI.Widget>();

        }

        public IEnumerable<UI.Widget> GetAllWidgets()
        {
            return Widgets;
        }

        public UI.Widget FindWidget(Guid id)
        {
            return Widgets.FirstOrDefault(q => q.Id == id);
        }

        public void AddWidget(UI.Widget widget)
        {
            Widgets.Add(widget);
        }

        public void DeledeteWidget(UI.Widget widget)
        {
            Widgets.Remove(widget);
        }
    }
}
