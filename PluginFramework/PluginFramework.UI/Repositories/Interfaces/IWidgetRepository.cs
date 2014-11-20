using System;
using System.Collections.Generic;

namespace PluginFramework.UI.Repositories.Interfaces
{
    public interface IWidgetRepository
    {
        IList<UI.Widget> Widgets { get; }

        IEnumerable<UI.Widget> GetAllWidgets();

        UI.Widget FindWidget(Guid id);

        void AddWidget(UI.Widget widget);

        void DeledeteWidget(UI.Widget widget);
    }
}
