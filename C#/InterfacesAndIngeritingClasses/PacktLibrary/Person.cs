using System;
using System.Collections.Generic;
using static System.Console;
namespace Packt.Shared
{
  public class Person : IComparable
  {
    // fields
    public string? Name;
    public DateTime DateOfBirth;
    public List<Person> Children = new List<Person>();
    // methods

    public void WriteToConsole()
    {
      WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }
    // static method to "multiply"
    public static Person Procreate(Person p1, Person p2)
    {
      var baby = new Person
      {
        Name = $"Baby of {p1.Name} and {p2.Name}"
      };
      p1.Children.Add(baby);
      p2.Children.Add(baby);
      return baby;
    }
    // instance method to "multiply"
    public Person ProcreateWith(Person partner)
    {
      return Procreate(this, partner);
    }

    // operator to "multiply"
    public static Person operator *(Person p1, Person p2)
    {
      return Person.Procreate(p1, p2);
    }

    // method with a local function
    public static ulong Factorial(ulong number)
    {
      if (number < 0)
      {
        throw new ArgumentException(
          $"{nameof(number)} cannot be less than zero.");
      }
      return localFactorial(number);

      ulong localFactorial(ulong localNumber) // local function
      {
        if (localNumber < 1) return 1;
        return localNumber * localFactorial(localNumber - 1);
      }
    }

    // Events
    // event delegate field
    public event EventHandler? Shout;

    // data field
    public int AngerLevel;

    public void Poke()
    {
      AngerLevel++;
      if (AngerLevel >= 3)
      {
        // if something is listening
        if (Shout != null)
        {
          // ... then call the delegate
          Shout(this, EventArgs.Empty);
          // Shout?.Invoke(this, EventArgs.Empty);
        }
      }
    }


  }
}
