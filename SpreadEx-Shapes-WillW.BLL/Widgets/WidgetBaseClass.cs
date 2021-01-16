using System;
using System.Drawing;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public abstract class WidgetBaseClass
    {
        public virtual WidgetType Type { get; }
        public virtual Point Location { get; set; }
        public virtual Func<string> GetDescription { get; }
        public Func<string> GetLocationString => () => $"({Location.X},{Location.Y})";
        public Func<int, string, int> GetUnitAndCheckPositive => (unit, unitName) => unit > 0 ? unit 
            : throw new OutOfBoundsUnitException($"A {Type} requires its {unitName} unit to be positive, currently it is {unit}");

        public WidgetBaseClass(Point location)
        {
            Location = location;
        }
    }
}
