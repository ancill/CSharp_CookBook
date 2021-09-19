using System;
using static System.Console;

namespace BitwiseOperators
{
  class Program
  {
    static void Main(string[] args)
    {
      int a = 10; // 0000 1010
      int b = 6; // 0000 0110
      WriteLine($"a = {a}");
      WriteLine($"b = {b}");
      WriteLine($"a & b = {a & b}"); // 2-bit column only
      WriteLine($"a | b = {a | b}"); // 8, 4, and 2-bit columns
      WriteLine($"a ^ b = {a ^ b}"); // 8 and 4-bit columns
    }
  }
}
