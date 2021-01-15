using System;
using System.Drawing;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public class EllipseWidget : WidgetBaseClass
    {
        public override WidgetType Type => WidgetType.Ellipse;
        public override Point Location { get; set; }
        public int HorizontalDiameter { get; set; }
        public int VerticleDiameter { get; set; }
        public override Func<string> GetDescription => () => $"{Type} {GetLocationString()} diameterH = {HorizontalDiameter} diameterV = {VerticleDiameter}";

        public EllipseWidget(Point location, int horizontalDiameter, int verticleDiameter)
        {
            Location = location;
            HorizontalDiameter = horizontalDiameter;
            VerticleDiameter = verticleDiameter;
        }
    }
}
