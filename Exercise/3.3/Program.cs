using System;
using static System.Console;
namespace _3._3
{
  class Program
  {
    static void Main(string[] args)
    {
      WriteLine("Simple FizzBuzz game!");

      for (int i = 0; i < 100; ++i)
      {
        var answer = "";
        if (i % 3 == 0) answer = "Fizz";
        if (i % 5 == 0) answer = "Buzz";
        if (i % 5 == 0 && i % 3 == 0) answer = "FizzBuzz";
        answer = String.IsNullOrEmpty(answer) ? i.ToString() : answer;
        Write($"{answer}\t");
      }
      WriteLine();
    }
  }
}
