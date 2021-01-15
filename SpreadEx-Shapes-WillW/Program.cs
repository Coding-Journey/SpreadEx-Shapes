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
            
            widgetCollection.AddRectangleWidget(new Point(10, 10), 30, 40);
            widgetCollection.AddSquareWidget(new Point(15, 30), 35);
            widgetCollection.AddEllipseWidget(new Point(100, 150), 300, 200);
            widgetCollection.AddCircleWidget(new Point(1, 1), 300);
            widgetCollection.AddTextboxWidget(new Point(5, 5), 200, 100, "sample text");

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
