using System.Collections.Generic;
using System.Linq;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public class WidgetCollection
    {
        public IList<GenericWidget> GenericWidgets;

        public WidgetCollection()
        {
            GenericWidgets = new List<GenericWidget>();
        }

        public void AddWidget(WidgetBaseClass widget)
        {
            switch(widget)
            {
                case TextboxWidget textboxWidget:
                    GenericWidgets.Add(new GenericWidget(textboxWidget));
                    break;
                case RectangleWidget rectangleWidget:
                    GenericWidgets.Add(new GenericWidget(rectangleWidget));
                    break;
                case SquareWidget squareWidget:
                    GenericWidgets.Add(new GenericWidget(squareWidget));
                    break;
                case EllipseWidget ellipseWidget:
                    GenericWidgets.Add(new GenericWidget(ellipseWidget));
                    break;
                case CircleWidget circleWidget:
                    GenericWidgets.Add(new GenericWidget(circleWidget));
                    break;          
                default:
                    throw new KeyNotFoundException($"Selected widget is not in the acceptable lists of widgets");
            }
        }

        public IEnumerable<string> GetDescriptions()
        {
            return GenericWidgets.Select(x => x.Widget.GetDescription());
        }
    }
}
