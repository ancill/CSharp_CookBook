using System;
using System.Collections.Generic;
using static System.Console;
namespace Packt.Shared
{

  public partial class Person : Object
  {
    // fields
    public string Name;
    public DateTime DateOfBirth;
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public List<Person> Children = new List<Person>();
    public const string Species = "Homo Sapien";
    // read-only fields
    public readonly string HomePlanet = "Earth";

    public readonly DateTime Instantiated;
    // constructors
    public Person()
    {
      // set default values for fields // including read-only fields
      Name = "Unknown";
      Instantiated = DateTime.Now;
    }
    public Person(string initialName, string homePlanet)
    {
      Name = initialName;
      HomePlanet = homePlanet;
      Instantiated = DateTime.Now;
    }
    // methods
    public void WriteToConsole()
    {
      WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }
    public string GetOrigin()
    {
      return $"{Name} was born on {HomePlanet}.";
    }

    public (string, int) GetFruit()
    {
      return ("Apples", 5);
    }

    public void PassingParameters(int x, ref int y, out int z)
    {
      // out parameters cannot have a default
      // AND must be initialized inside the method
      z = 99;
      // increment each parameter
      x++;
      y++;
      z++;
    }

  }
}
