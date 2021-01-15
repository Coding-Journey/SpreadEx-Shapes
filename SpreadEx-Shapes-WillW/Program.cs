using System;
using SpreadEx_Shapes_WillW.BLL.Widgets;
using Point = System.Drawing.Point;

namespace SpreadEx_Shapes_WillW
{
    class Program
    {
        static void Main()
        {
            var widgetCollection = new WidgetCollection();
            
            widgetCollection.AddWidget(new RectangleWidget(new Point(10, 10), 30, 40));
            widgetCollection.AddWidget(new SquareWidget(new Point(15, 30), 35));
            widgetCollection.AddWidget(new EllipseWidget(new Point(100, 150), 300, 200));
            widgetCollection.AddWidget(new CircleWidget(new Point(1, 1), 300));
            widgetCollection.AddWidget(new TextboxWidget(new Point(5, 5), 200, 100, "sample text"));

            var descriptions = widgetCollection.GetDescriptions();

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Requested Drawing");
            Console.WriteLine("----------------------------------------------------------------");
            descriptions.ForEach(desc => Console.WriteLine(desc));
            Console.WriteLine("----------------------------------------------------------------");

            Console.ReadKey();
        }
    }
}
