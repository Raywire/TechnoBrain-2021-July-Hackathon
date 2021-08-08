## Question 1
Create a console application named Exercise01 that prompts the user to enter a regular expression, and then prompts the user to enter some input and compare the two for a match until the user presses ESC, as shown in the following output:

The default regular expression checks for at least one digit.

```
The default regular expression checks for at least one digit.
Enter a regular expression (or press ENTER to use the default): ^[a-z]+$
Enter some input: apples
apples matches ^[a-z]+$? True
Press ESC to end or any key to try again.
Enter a regular expression (or press ENTER to use the default): ^[a-z]+$
Enter some input: abc123xyz
abc123xyz matches ^[a-z]+$? False
Press ESC to end or any key to try again.
```

Create a class library named Exercise02 that defines extension methods that extend number types such as BigInteger and int with a method named ToWords that returns a string describing the number; for example 18,000,000 would be eighteen million, and 18,456,002,032,011,000,007 would be eighteen quintillion, four hundred and fifty six quadrillion, two trillion, thirty two billion, eleven million, and seven

Create a console application named Exercise03 that uses the class library in Exercise02 to take numeric input from the user and output the string describing the number.

## Question 2

Create a console application named Exercise04 that creates a list of shapes, uses serialization to save it to the filesystem using XML, and then deserializes it back:

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
### Question 3
Create a console application named Exercise05 that protects an XML file, such as the following example:
```xml
<?xml version="1.0" encoding="utf-8" ?>
<customers>
  <customer>
    <name>Bob Smith</name>
    <creditcard>1234-5678-9012-3456</creditcard>
    <password>Pa$$w0rd</password>
  </customer>
...
</customers>

```
The customer's credit card number and password are currently stored in clear text. The credit card number must be encrypted so that it can be decrypted and used later, and the password must be salted and hashed.

Create a console application named Exercise06 that opens the XML file that you protected in the preceding code and decrypts the credit card number.