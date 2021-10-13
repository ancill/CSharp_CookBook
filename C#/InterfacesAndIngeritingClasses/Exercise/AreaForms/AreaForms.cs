
namespace AreaForms
{
  public class Shape
  {
    public readonly double Height;
    public readonly double Width;

    public virtual double Area { get; set; }

    public Shape(double height, double width)
    {
      Height = height;
      Width = width;
      Area = height * width;
    }
  }
  public class Ractangle : Shape
  {
    public Ractangle(double height, double width) : base(height, width)
    {
      Area = height * width;
    }
  }
  public class Square : Shape
  {
    public Square(double height) : base(height, width)
    {

      Area = height * height;
    }
  }
  public class Circle : Shape
  {
    public Circle(double diametr) : base(height, width)
    {
      Area = diametr * Math.PI;
    }
  }
}
