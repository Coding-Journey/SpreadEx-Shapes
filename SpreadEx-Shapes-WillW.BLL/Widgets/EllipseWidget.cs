using System;
using System.Drawing;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public class EllipseWidget : WidgetBaseClass
    {
        public int HorizontalDiameter { get; set; }
        public int VerticleDiameter { get; set; }
        public override WidgetType Type { get => WidgetType.Ellipse; }
        public override Func<string> GetDescription => () => $"{Type} {GetLocationString()} diameterH = {HorizontalDiameter} diameterV = {VerticleDiameter}";

        public EllipseWidget(Point location, int horizontalDiameter, int verticleDiameter) 
            : base(location)
        {
            HorizontalDiameter = GetUnitAndCheckPositive(horizontalDiameter, nameof(horizontalDiameter));
            VerticleDiameter = GetUnitAndCheckPositive(verticleDiameter, nameof(verticleDiameter));
        }
    }
}
