using System.Drawing;
using NUnit.Framework;
using SpreadEx_Shapes_WillW.BLL.Widgets;
using SpreadEx_Shapes_WillW.BLL;

namespace SpreadEx_Shapes_WillW.UnitTests.Widgets
{
    [TestFixture]
    internal class WidgetBaseClassTests
    {
        [Test]
        public void TestGetLocationString()
        {
            var widgetTestClass = new WidgetTestClass(new Point(1, 2));

            Assert.AreEqual("(1,2)", widgetTestClass.GetLocationString());
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void TestGetUnitAndCheckPositiveThrowsException(int unit)
        {
            var widgetTestClass = new WidgetTestClass(new Point(1, 2));

            var exception = Assert.Throws<OutOfBoundsUnitException>(
                () => widgetTestClass.GetUnitAndCheckPositive(unit, "unitName"));

            Assert.AreEqual(
                $"A Circle requires its unitName unit to be positive, currently it is {unit}", exception.Message);
        }

        private class WidgetTestClass : WidgetBaseClass
        {
            public new readonly WidgetType Type = WidgetType.Circle;

            public WidgetTestClass(Point location) : base(location)
            {
                
            }
        }
    }
}
