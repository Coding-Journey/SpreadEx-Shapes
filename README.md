# SpreadEx-Shapes-WillW
Coding exercise for SpreadEx

## Running program:
Set Shapes.Application as Startup project or just hit run on Program.cs

## Running Tests:
Right click on Shapes.Bll.UnitTests and run tests on the assembly

## Design Decisions:


General idea was to provide a BaseWidget class that had some common aspects of widgets, that could then be inherited by the shape widgets.
This was so that code could be reused, the solution is easily extensible, especially when adding new shapes and functions.
  E.g. Adding a triangle would be a simple TriangleWidget : WidgetBaseClass, with an extra unique property of width & height
  E.g. Adding a func<int> GetArea to the base class would allow all the child classes to override their own area calculation. (circle pi*r^2, square size^2). 
       This would then be easily queryable like the GetDescription function, so moving from printing descriptions to also printing areas would be trivial.
This decision also makes the code maintainable as code isn't being re-used everywhere, descrete classes can have robust unit tests.

As all the widgets inherit the same baseClass, we have the ability to group a collection of different widgets together in an IEnumerable array of GenericWidgets.
GenericWidget is a simple wrapper class that has a single property of WidgetBaseClassWidget. Each of our shape widgets is assignable to this property as they inherit WidgetBaseClass, this provides a crucial advantage. We can now group all the added widgets, of different types to a single typed list, this makes adding, editing and querying far easier in our helper class: WidgetCollection.

WidgetCollection has a single public Property GenericWidgets, which is the store for all of the widgets that will get added to our drawing.
WidgetCollection.AddWidget() is a very powerful single interface method, we can add any widget of our choosing that inherits WidgetBaseClass, the method then switches based on type of widget, then adding it to our GenericWidgets collection. Importantly, as this switched and casts the widgettype then adds the specific widgetType to our collection, we retain important unique information of each type of shape widget
WidgetCollection.GetDescriptions() is a simple method that uses Linq to iterate through our widgets, calling the GetDescription() Func on each of them, allowing us to easily build up a string list of descriptions that are ready to be displayed.

Our console method then just needs to create a new WidgetCollection, Add some shapeWidgets with .Add, then print out the List of descriptions returned by .GetDescriptions,
having our business logic in another assembly has made the code clean and testable.


## 3 Assembly Structure:

- Shapes.Application (Front-End Console Application)
  - No business logic
  - Adds items to WidgetCollection
  - Displays descriptions of Widgets through console logging
  
- Shapes.BLL (Back-End Business Logic)
  - Widgets
    - WidgetType
      -Enum storing Widget Types e.g. WidgetType.Circle
  - WidgetBaseClass
    - BaseClass for all widgets
    - Overridable properties for common asbects of widgets
    - GetLocationString() Func that formats a System.Drawing.Point into the "(x,y)" point format requested
    - GetDescription() overridable Func that formats the shapes properties into a nice string, very useful when pulling out descriptions effortlessly from a list of shapes
    - inherits base class: CircleWidget, EllipseWidget, RectangleWidget, SquareWidget, TextboxWidget
  - WidgetHelpers
    - GenericWidget
      -Wrapper class for storing any widget that inherits WidgetBaseClass
    - WidgetCollection
      -Stores list of widgets (drawing)
      -handles adding of widgets
      -provides method to GetDescriptions of all widgets in our drawing
  - OutOfBoundUnitException
    - Thrown when width, height or diameter is set but the value isn't positive
      
 - Shapes.BLL.UnitTests (Back-End UnitTests)
   - WidgetCollectiontests
     - tests adding of widgets and collating of descriptions
   - WidgetBaseClassTests
     - tests GetUnitAndCheckPositive func throws the correct exception or returns int
     - tests GetLocationString func works as intended
