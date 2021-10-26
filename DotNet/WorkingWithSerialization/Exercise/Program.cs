using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Shapes;
using static System.Environment;
using static System.IO.Path;
using static System.Console;

namespace Exercise
{
  class Program
  {
    static void Main(string[] args)
    {
      // create a list of Shapes to serialize
      var listOfShapes = new List<Shape>
        {
        new Circle { Colour = "Red", Radius = 2.5 },
        new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
        new Circle { Colour = "Green", Radius = 8.0 },
        new Circle { Colour = "Purple", Radius = 12.3 },
        new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 }
        };
      var serializerXml = new XmlSerializer(typeof(List<Shape>)); // create a file to write to
      string path = Combine(CurrentDirectory, "shapes.xml");
      using (FileStream stream = File.Create(path))
      {
        // serialize the object graph to the stream
        serializerXml.Serialize(stream, listOfShapes);
      }
      WriteLine("Written {0:N0} bytes of XML to {1}",
        arg0: new FileInfo(path).Length,
        arg1: path);
      WriteLine();
      // Display the serialized object graph
      WriteLine(File.ReadAllText(path));


      using (FileStream fileXml = File.Open(path, FileMode.Open))
      {
        // deserialize and cast the object graph into a List of Shapes
        List<Shape> loadedShapesXml = serializerXml.Deserialize(fileXml) as List<Shape>;
        foreach (Shape item in loadedShapesXml)
        {
          WriteLine("{0} is {1} and has an area of {2:N2}",
            item.GetType().Name, item.Colour, item.Area);
        }
      }
    }
  }
}
