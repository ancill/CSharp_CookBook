using System;
using static System.Console;

namespace _3._2
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        checked
        {
          int max = 500;
          for (byte i = 0; i < max; i++)
          {
            WriteLine(i);
          }
        }
      }
      catch (OverflowException)
      {
        WriteLine("The code overflowed but I caught the exception.");
      }
      catch (Exception ex)
      {
        WriteLine($"{ex.GetType()} says {ex.Message}");

      }

    }
  }
}
