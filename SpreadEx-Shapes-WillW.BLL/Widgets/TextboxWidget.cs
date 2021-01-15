using System;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public class TextboxWidget : RectangleWidget
    {
        public override WidgetType Type => WidgetType.Textbox;
        public string Text { get; set; }
        public override Func<string> GetDescription => () => $"{Type} {GetLocationString()} width={Width} height={Height} Text=\"{Text}\"";
    }
}