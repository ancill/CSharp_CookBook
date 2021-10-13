
namespace Area.Shared
{
  public abstract class Shape
  {
    // fields
    // protected - only inside this class and class that inherit it
    protected double height;
    protected double width;

    // properties
    public virtual double Height
    {
      get
      {
        return height;
      }
      set
      {
        height = value;
      }
    }

    public virtual double Width
    {
      get
      {
        return width;
      }
      set
      {
        width = value;
      }
    }

    // Area must be implemented by derived classes
    // as a read-only property
    public virtual double Area { get; }
  }


  public class Rectangle : Shape
  {
    public Rectangle() { }

    public Rectangle(double height, double width)
    {
      this.height = height;
      this.width = width;
    }

    public override double Area
    {
      get
      {
        return height * width;
      }
    }
  }

  public class Square : Shape
  {
    public Square() { }
    public Square(double width)
    {
      this.height = width;
      this.width = width;
    }
    public override double Area
    {
      get
      {
        return height * width;
      }
    }
  }

  public class Circle : Square
  {
    public Circle() { }
    public Circle(double radius) : base(width: radius * 2) { }
    public double Radius
    {
      get
      {
        return height / 2;
      }
      set
      {
        Height = value * 2;
      }
    }

    public override double Area
    {
      get
      {
        var radius = height / 2;
        return System.Math.PI * radius * radius;
      }
    }
  }

}
