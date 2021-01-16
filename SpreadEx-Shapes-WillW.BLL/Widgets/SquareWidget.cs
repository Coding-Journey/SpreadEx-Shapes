using System;
using System.Drawing;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public class SquareWidget : WidgetBaseClass
    {
        public int Size { get; set; }
        public new readonly WidgetType Type = WidgetType.Square;
        public override Func<string> GetDescription => () => $"{Type} {GetLocationString()} size={Size}";

        public SquareWidget(Point location, int size) 
            : base(location)
        {
            Size = GetUnitAndCheckPositive(size, nameof(size));
        }
    }
}
