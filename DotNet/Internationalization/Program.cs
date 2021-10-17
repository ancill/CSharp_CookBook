using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using static System.Console;

namespace MyApp // Note: actual namespace depends on the project name.
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CultureInfo globalization = CultureInfo.CurrentCulture;
      CultureInfo localization = CultureInfo.CurrentUICulture;

      WriteLine("The current globalization culture is {0}: {1}",
        globalization.Name, globalization.DisplayName);
      WriteLine("The current localization culture is {0}: {1}",
        localization.Name, localization.DisplayName);
      WriteLine();

      WriteLine("en-US: English (United States)");
      WriteLine("da-DK: Danish (Denmark)");
      WriteLine("fr-CA: French (Canada)");
      WriteLine("ru-RUS: Russian (Moscow)");

      Write("Enter an ISO culture code: ");
      string newCulture = ReadLine();
      if (!string.IsNullOrEmpty(newCulture))
      {
        var ci = new CultureInfo(newCulture);
        CultureInfo.CurrentCulture = ci;

        CultureInfo.CurrentUICulture = ci;
      }
      WriteLine();
      Write("Enter your name: ");
      string name = ReadLine();
      Write("Enter your date of birth: ");
      string dob = ReadLine();
      Write("Enter your salary: ");
      string salary = ReadLine();
      DateTime date = DateTime.Parse(dob);
      int minutes = (int)DateTime.Today.Subtract(date).TotalMinutes;
      decimal earns = decimal.Parse(salary);
      int age = (int)DateTime.Today.Subtract(date).TotalDays / 365;
      WriteLine(
        "{0} was born on a {1:dddd}, is {2:N0} minutes old, and earns {3:C} and {4:D} years old",
        name, date, minutes, earns, age);
    }
  }
}
