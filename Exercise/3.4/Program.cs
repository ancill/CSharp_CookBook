using System;
using static System.Console;
namespace _3._4
{
  class Program
  {
    static void Main(string[] args)
    {

      try
      {
        WriteLine($"Enter a number between 0 and 255:");
        var input1 = uint.Parse(ReadLine());
        WriteLine("Enter another number between 0 and 255:");
        var input2 = uint.Parse(ReadLine());
        if (input1 > 255 || input2 > 255) throw new OverflowException();
        WriteLine($"{input1} divided by {input2} is {input1 / input2}");
      }
      catch (FormatException FE)
      {
        WriteLine($"{FE.GetType()}: Input string was not in a correct format.");
      }
      catch (DivideByZeroException)
      {
        WriteLine("Divided by zero!");
      }
      catch (OverflowException)
      {
        WriteLine("Provided number less then 0 or more then 255");
      }
      catch (Exception ex)
      {
        WriteLine(ex);
      }
    }
  }
}
