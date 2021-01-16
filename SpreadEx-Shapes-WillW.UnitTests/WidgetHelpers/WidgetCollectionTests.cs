using NUnit.Framework;
using SpreadEx_Shapes_WillW.BLL.Widgets;
using System.Collections.Generic;
using System.Linq;
using Point = System.Drawing.Point;

namespace SpreadEx_Shapes_WillW.UnitTests.WidgetHelpers
{
    [TestFixture]
    internal class WidgetCollectionTests
    {
        private WidgetCollection _widgetCollection;

        [SetUp]
        public void SetUp()
        {
            _widgetCollection = new WidgetCollection();
        }

        [Test]
        public void TestAddTextbox()
        {
            var location = new Point(1, 2);

            _widgetCollection.AddWidget(new TextboxWidget(location, 3, 4, "text"));

            Assert.AreEqual(1, _widgetCollection.GenericWidgets.Count);

            var textboxWidget =_widgetCollection.GenericWidgets.SingleOrDefault().Widget as TextboxWidget;

            Assert.AreEqual(WidgetType.Textbox, textboxWidget.Type);
            Assert.AreEqual(location, textboxWidget.Location);
            Assert.AreEqual(3, textboxWidget.Width);
            Assert.AreEqual(4, textboxWidget.Height);
            Assert.AreEqual("text", textboxWidget.Text);
            Assert.AreEqual("Textbox (1,2) width=3 height=4 Text=\"text\"", textboxWidget.GetDescription());
        }

        [Test]
        public void TestAddRectangle()
        {
            var location = new Point(1, 2);

            _widgetCollection.AddWidget(new RectangleWidget(location, 3, 4));

            Assert.AreEqual(1, _widgetCollection.GenericWidgets.Count);

            var rectangleWidget = _widgetCollection.GenericWidgets.SingleOrDefault().Widget as RectangleWidget;

            Assert.AreEqual(WidgetType.Rectangle, rectangleWidget.Type);
            Assert.AreEqual(location, rectangleWidget.Location);
            Assert.AreEqual(3, rectangleWidget.Width);
            Assert.AreEqual(4, rectangleWidget.Height);
            Assert.AreEqual("Rectangle (1,2) width=3 height=4", rectangleWidget.GetDescription());
        }

        [Test]
        public void TestAddSquare()
        {
            var location = new Point(1, 2);

            _widgetCollection.AddWidget(new SquareWidget(location, 3));

            Assert.AreEqual(1, _widgetCollection.GenericWidgets.Count);

            var squareWidget = _widgetCollection.GenericWidgets.SingleOrDefault().Widget as SquareWidget;

            Assert.AreEqual(WidgetType.Square, squareWidget.Type);
            Assert.AreEqual(location, squareWidget.Location);
            Assert.AreEqual(3, squareWidget.Size);
            Assert.AreEqual("Square (1,2) size=3", squareWidget.GetDescription());
        }

        [Test]
        public void TestAddEllipse()
        {
            var location = new Point(1, 2);

            _widgetCollection.AddWidget(new EllipseWidget(location, 3, 4));

            Assert.AreEqual(1, _widgetCollection.GenericWidgets.Count);

            var ellipseWidget = _widgetCollection.GenericWidgets.SingleOrDefault().Widget as EllipseWidget;

            Assert.AreEqual(WidgetType.Ellipse, ellipseWidget.Type);
            Assert.AreEqual(location, ellipseWidget.Location);
            Assert.AreEqual(3, ellipseWidget.HorizontalDiameter);
            Assert.AreEqual(4, ellipseWidget.VerticleDiameter);
            Assert.AreEqual("Ellipse (1,2) diameterH = 3 diameterV = 4", ellipseWidget.GetDescription());
        }

        [Test]
        public void TestAddCircle()
        {
            var location = new Point(1, 2);

            _widgetCollection.AddWidget(new CircleWidget(location, 3));

            Assert.AreEqual(1, _widgetCollection.GenericWidgets.Count);

            var circleWidget = _widgetCollection.GenericWidgets.SingleOrDefault().Widget as CircleWidget;

            Assert.AreEqual(WidgetType.Circle, circleWidget.Type);
            Assert.AreEqual(location, circleWidget.Location);
            Assert.AreEqual(3, circleWidget.Size);
            Assert.AreEqual("Circle (1,2) size=3", circleWidget.GetDescription());
        }

        [Test]
        public void TestGetDescriptions()
        {
            var expectedDescriptions = new[]
            {
                "Rectangle (10,10) width=30 height=40",
                "Square (15,30) size=35",
                "Ellipse (100,150) diameterH = 300 diameterV = 200",
                "Circle (1,1) size=300",
                "Textbox (5,5) width=200 height=100 Text=\"sample text\""
            };

            _widgetCollection.AddWidget(new RectangleWidget(new Point(10, 10), 30, 40));
            _widgetCollection.AddWidget(new SquareWidget(new Point(15, 30), 35));
            _widgetCollection.AddWidget(new EllipseWidget(new Point(100, 150), 300, 200));
            _widgetCollection.AddWidget(new CircleWidget(new Point(1, 1), 300));
            _widgetCollection.AddWidget(new TextboxWidget(new Point(5, 5), 200, 100, "sample text"));

            var descriptions = _widgetCollection.GetDescriptions();

            Assert.AreEqual(expectedDescriptions.Count(), descriptions.Count());
            Assert.IsTrue(descriptions.All(desc => expectedDescriptions.Contains(desc)));
        }

        [Test]
        public void AddUnexpectedWidget()
        {
            var exception = Assert.Throws<KeyNotFoundException>(
                    () => _widgetCollection.AddWidget(new UnexpectedWidgetTestClass(new Point(1, 2))));
            Assert.AreEqual("Selected widget is not in the acceptable lists of widgets", exception.Message);
        }

        private class UnexpectedWidgetTestClass : WidgetBaseClass
        {
            public UnexpectedWidgetTestClass(Point location)
                : base(location) { }
        }
    }    
}
