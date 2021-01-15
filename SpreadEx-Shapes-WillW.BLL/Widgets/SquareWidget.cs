using System;
using System.Drawing;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public class SquareWidget : WidgetBaseClass
    {
        public override WidgetType Type => WidgetType.Square;
        public override Point Location { get; set; }
        public int Size { get; set; }
        public override Func<string> GetDescription => () => $"{Type} {GetLocationString()} size={Size}";

    }
}
