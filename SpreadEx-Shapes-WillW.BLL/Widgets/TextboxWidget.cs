using System;
using System.Drawing;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public class TextboxWidget : RectangleWidget
    {
        public override WidgetType Type { get => WidgetType.Textbox; }
        public string Text { get; set; }
        public override Func<string> GetDescription => () => $"{Type} {GetLocationString()} width={Width} height={Height} Text=\"{Text}\"";

        public TextboxWidget(Point location, int width, int height, string text) :
            base(location, width, height)
        {
            Text = text;
        }
    }
}