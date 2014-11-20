using System;
using System.Collections.Generic;

namespace PluginFramework.UI
{
    public class Widget
    {
        public Guid Id { set; get; }
        public int Order { set; get; }
        public string Section { set; get; }
        public string ClassName { set; get; }
        public string HeaderText { set; get; }
        public string FooterText { set; get; }
        public bool IsActive { set; get; }
        public bool HasSubWidget { set; get; }
        public virtual IList<Widget> SubWidgets { set; get; }

    }
}
