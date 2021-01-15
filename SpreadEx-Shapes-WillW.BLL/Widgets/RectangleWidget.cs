﻿using System;
using System.Drawing;

namespace SpreadEx_Shapes_WillW.BLL.Widgets
{
    public class RectangleWidget : WidgetBaseClass
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public override WidgetType Type => WidgetType.Rectangle;
        public override Point Location { get; set; }
        public override Func<string> GetDescription => () => $"{Type} {GetLocationString()} width={Width} height={Height}";

    }
}