using System;
using System.Drawing;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public class CircleWidget : WidgetBaseClass
    {
        public int Size { get; set; }
        public new readonly WidgetType Type = WidgetType.Circle;
        public override Func<string> GetDescription => () => $"{Type} {GetLocationString()} size={Size}";

        public CircleWidget(Point location, int size) 
            : base(location)
        {
            Size = GetUnitAndCheckPositive(size, nameof(size));
        }
    }
}
