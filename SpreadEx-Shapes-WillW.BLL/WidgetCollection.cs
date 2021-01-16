using System.Collections.Generic;
using System.Linq;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public class WidgetCollection
    {
        private IList<GenericWidget> _genericWidgets;

        public WidgetCollection()
        {
            _genericWidgets = new List<GenericWidget>();
        }

        public void AddWidget(WidgetBaseClass widget)
        {
            switch(widget)
            {
                case TextboxWidget textboxWidget:
                    _genericWidgets.Add(new GenericWidget(textboxWidget));
                    break;
                case RectangleWidget rectangleWidget:
                    _genericWidgets.Add(new GenericWidget(rectangleWidget));
                    break;
                case SquareWidget squareWidget:
                    _genericWidgets.Add(new GenericWidget(squareWidget));
                    break;
                case EllipseWidget ellipseWidget:
                    _genericWidgets.Add(new GenericWidget(ellipseWidget));
                    break;
                case CircleWidget circleWidget:
                    _genericWidgets.Add(new GenericWidget(circleWidget));
                    break;          
                default:
                    throw new KeyNotFoundException($"Selected widget is not in the acceptable lists of widgets");
            }
        }

        public IEnumerable<string> GetDescriptions()
        {
            return _genericWidgets.Select(x => x.Widget.GetDescription());
        }
    }
}
