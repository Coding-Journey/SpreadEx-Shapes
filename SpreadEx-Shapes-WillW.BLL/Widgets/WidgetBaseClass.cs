using System;
using System.Drawing;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public enum WidgetType
    {
        Circle,
        Ellipse,
        Rectangle,
        Square,
        Textbox
    }

    public abstract class WidgetBaseClass
    {
        public virtual WidgetType Type { get; }
        public virtual Point Location { get; set; }
        public virtual Func<string> GetDescription { get; }
        public Func<string> GetLocationString => () => $"({Location.X},{Location.Y})";
        //TODO: write unit test to check that this works for all expected units that we want to be positive
        public Func<int, string, int> GetUnitAndCheckPositive => (unit, unitName) => unit > 0 ? unit 
            : throw new OutOfBoundsUnitException($"A {Type} requires its {unitName} unit to be positive, currently it is {unit}");

        public WidgetBaseClass(Point location)
        {
            Location = location;
        }
    }
}
