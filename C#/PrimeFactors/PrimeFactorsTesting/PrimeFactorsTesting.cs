using System;
using Xunit;
using PrimeFactorsUtils;


namespace PrimeFactorsTesting
{
  public class TestingPrimeFactorsUtils
  {
    [Fact]
    public void GetPrimeOf4()
    {
      // arange
      string expected = "2 x 2";
      int a = 4;
      var prime = new PrimeFactorsCalculate();

      // act
      string actual = prime.GetPrimeFactorOfNumber(a);
      // assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void GetPrimeOf7()
    {
      // arange
      string expected = "7";
      int a = 7;
      var prime = new PrimeFactorsCalculate();

      // act
      string actual = prime.GetPrimeFactorOfNumber(a);
      // assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void GetPrimeOf30()
    {
      // arange
      string expected = "5 x 3 x 2";
      int a = 30;
      var prime = new PrimeFactorsCalculate();

      // act
      string actual = prime.GetPrimeFactorOfNumber(a);
      // assert
      Assert.Equal(expected, actual);
    }
  }
}
