using SpreadEx_Shapes_WillW.BLL.Widgets;
using System;

namespace SpreadEx_Shapes_WillW.BLL
{
    public class GenericWidget
    {
        public WidgetBaseClass Widget;

        public GenericWidget(WidgetBaseClass widget)
        {
            Widget = widget ?? throw new ArgumentNullException(nameof(widget));
        }
    }
}
