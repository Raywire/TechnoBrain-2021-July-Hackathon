using System;
using System.Collections.Generic;
using static System.IO.Path;
using static System.Environment;
using System.IO;
using System.Xml.Serialization;

namespace Exercise04
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfShapes = new List<Shape>
            {
                new Circle { Colour = "Red", Radius = 2.5 },
                new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
                new Circle { Colour = "Green", Radius = 8.0 },
                new Circle { Colour = "Purple", Radius = 12.3 },
                new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 },
            };

            string xmlFile = Combine(CurrentDirectory, "shapes.xml");
            FileStream fileStream = File.Create(xmlFile);

            var serializerXml = new XmlSerializer(typeof(List<Shape>));
            serializerXml.Serialize(fileStream, listOfShapes);

            fileStream.Close();

            FileStream xmlLoad = File.Open(xmlFile, FileMode.Open);

            var loadedShapesXml = (List<Shape>)serializerXml.Deserialize(xmlLoad);
            foreach (Shape item in loadedShapesXml)
            {
                Console.WriteLine("{0} is {1} and has an area of {2:N2}", item.GetType().Name, item.Colour, item.Area);
            }
            xmlLoad.Close();
        }
    }
}
