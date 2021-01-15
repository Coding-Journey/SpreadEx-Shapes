using System.Collections.Generic;
using System.Linq;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    //TODO: I think there is a better way of storing these, plus these wont be in order, it will print all the same things together, not ideal
    //could give them a unique id that will allow me to have them in order of adding, that'd be nice, again might be a better way of storing them
    //could give a positionAdded id to base, that'd work
    public class WidgetCollection
    {
        private IList<RectangleWidget> _rectangleWidgets;
        private IList<SquareWidget> _squareWidgets;
        private IList<EllipseWidget> _ellipseWidgets;
        private IList<CircleWidget> _circleWidgets;
        private IList<TextboxWidget> _textboxWidgets;

        public WidgetCollection()
        {
            _rectangleWidgets = new List<RectangleWidget>();
            _squareWidgets = new List<SquareWidget>();
            _ellipseWidgets = new List<EllipseWidget>();
            _circleWidgets = new List<CircleWidget>();
            _textboxWidgets = new List<TextboxWidget>();
        }

        public void AddWidget(WidgetBaseClass widget)
        {
            switch(widget)
            {
                case TextboxWidget textboxWidget:
                    _textboxWidgets.Add(textboxWidget);
                    break;
                case RectangleWidget rectangleWidget:
                    _rectangleWidgets.Add(rectangleWidget);
                    break;
                case SquareWidget squareWidget:
                    _squareWidgets.Add(squareWidget);
                    break;
                case EllipseWidget ellipseWidget:
                    _ellipseWidgets.Add(ellipseWidget);
                    break;
                case CircleWidget circleWidget:
                    _circleWidgets.Add(circleWidget);
                    break;          
                default:
                    throw new KeyNotFoundException($"Specified Type: {widget.Type} is not in the acceptable lists of widgets");
            }
        }
        public List<string> GetDescriptions()
        {
            //gotta be a better way, too prone to not including it here
            var descriptions = new List<string>();

            descriptions.AddRange(_rectangleWidgets.Select(x => x.GetDescription()));
            descriptions.AddRange(_squareWidgets.Select(x => x.GetDescription()));
            descriptions.AddRange(_ellipseWidgets.Select(x => x.GetDescription()));
            descriptions.AddRange(_circleWidgets.Select(x => x.GetDescription()));
            descriptions.AddRange(_textboxWidgets.Select(x => x.GetDescription()));

            return descriptions;
        }
    }
}
