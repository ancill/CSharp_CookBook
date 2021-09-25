using System;

namespace _3._1
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("What happens when you divide an int variable by 0?");
      int l = 5;
      Console.WriteLine($"{l / 0}"); // Unhandled exception. System.DivideByZeroException: Attempted to divide by zero.
      Console.WriteLine("What happens when you divide an decimal variable by 0?");
      decimal d = 10.0M;
      Console.WriteLine($"{d / 0}"); // Unhandled exception. System.DivideByZeroException: Attempted to divide by zero.
      int max = 500;
      for (byte i = 0; i < max; i++)
      {
        Console.WriteLine(i);
      }
    }
  }
}
