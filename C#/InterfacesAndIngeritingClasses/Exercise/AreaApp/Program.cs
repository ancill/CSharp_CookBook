using AreaForms;
using static System.Console;

// var s = new Square(5);
// WriteLine($"Square H: {s.Height}, W: {s.Width}, Area: {s.Area}");
// var c = new Circle(2.5);
// WriteLine($"Circle H: {c.Height}, W: {c.Width}, Area: {c.Area}");


namespace AreaApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var r = new AreaForms.Ractangle(3, 4.5);
      WriteLine($"Rectangle H: {r.Height}, W: {r.Width}, Area: {r.Area}");
      var s = new AreaForms.Square(5);
      WriteLine($"Square H: {s.Height}, W: {s.Width}, Area: {s.Area}");
      var c = new AreaForms.Circle(2.5);
      WriteLine($"Circle H: {c.Height}, W: {c.Width}, Area: {c.Area}");
    }
  }
}
