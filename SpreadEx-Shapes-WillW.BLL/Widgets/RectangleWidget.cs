using System;
using System.Drawing;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public class RectangleWidget : WidgetBaseClass
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public new readonly WidgetType Type = WidgetType.Rectangle;
        public override Func<string> GetDescription => () => $"{Type} {GetLocationString()} width={Width} height={Height}";

        public RectangleWidget(Point location, int width, int height) 
            : base(location)
        {
            Width = GetUnitAndCheckPositive(width, nameof(width));
            Height = GetUnitAndCheckPositive(height, nameof(height));
        }

    }
}
