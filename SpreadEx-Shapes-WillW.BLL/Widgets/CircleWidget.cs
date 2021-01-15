using System;
using System.Drawing;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public class CircleWidget : WidgetBaseClass
    {
        public override WidgetType Type => WidgetType.Circle;
        public override Point Location { get; set; }
        public int Size { get; set; }
        public override Func<string> GetDescription => () => $"{Type} {GetLocationString()} size={Size}";
    }
}
