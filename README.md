### Question 2

Create a console application named Exercise 04 that creates a list of shapes, uses serialization to save it to the filesystem using XML, and then deserializes it back:

```csharp
// create a list of Shapes to serialize
var listOfShapes = new List<Shape>
{
  new Circle { Colour = "Red", Radius = 2.5 },
  new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
  new Circle { Colour = "Green", Radius = 8.0 },
  new Circle { Colour = "Purple", Radius = 12.3 },
  new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 },
}

Shapes should have a read-only property named Area so that when you deserialize, you can output a list of shape, including their areas, as shown here:
List<Shape> loadedShapesXml = serializerXml.Deserialize(fileXml) as List<Shape>;
foreach (Shape item in loadedShapesXml)
{
  WriteLine("{0} is {1} and has an area of {2:N2}", item.GetType().Name, item.Colour, item.Area);
}
```
