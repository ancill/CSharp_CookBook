using System;
using Packt.Shared;
using static System.Console;
namespace PeopleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var bob = new Person();
      bob.Name = "Bob Smith";
      bob.DateOfBirth = new DateTime(1965, 12, 22);
      bob.FavoriteAncientWonder =
        WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

      bob.BucketList =
      WondersOfTheAncientWorld.HangingGardensOfBabylon
      | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

      WriteLine(format:
        "{0}'s favorite wonder is {1}. Its integer is {2}.",
            arg0: bob.Name,
            arg1: bob.FavoriteAncientWonder,
            arg2: (int)bob.FavoriteAncientWonder);

      var alice = new Person
      {
        Name = "Alice Jones",
        DateOfBirth = new DateTime(1998, 3, 7)
      };
      WriteLine(format: "{0} was born on {1:dd MMM yy}",
        arg0: alice.Name,
        arg1: alice.DateOfBirth);
      WriteLine($"{bob.Name} is a {Person.Species}");
      WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

      bob.Children.Add(new Person { Name = "Alfred" });
      bob.Children.Add(new Person { Name = "Zoe" });

      WriteLine($"{bob.Name} has {bob.Children.Count} children:");
      for (int child = 0; child < bob.Children.Count; child++)
      {
        WriteLine($"  {bob.Children[child].Name}");
      }


      BankAccount.InterestRate = 0.012M; // store a shared value

      var jonesAccount = new BankAccount();
      jonesAccount.AccountName = "Mrs. Jones";
      jonesAccount.Balance = 2400;

      WriteLine(format: "{0} earned {1:C} interest.",
        arg0: jonesAccount.AccountName,
        arg1: jonesAccount.Balance * BankAccount.InterestRate);

      var gerrierAccount = new BankAccount();
      gerrierAccount.AccountName = "Ms. Gerrier";
      gerrierAccount.Balance = 98;

      WriteLine(format: "{0} earned {1:C} interest.",
        arg0: gerrierAccount.AccountName,
        arg1: gerrierAccount.Balance * BankAccount.InterestRate);


      var blankPerson = new Person();
      WriteLine(format:
        "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
        arg0: blankPerson.Name,
        arg1: blankPerson.HomePlanet,
        arg2: blankPerson.Instantiated);

      var gunny = new Person("Gunny", "Mars");
      WriteLine(format:
        "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
        arg0: gunny.Name,
        arg1: gunny.HomePlanet,
        arg2: gunny.Instantiated);



    }
  }
}
