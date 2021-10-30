using System.Linq;
using Microsoft.EntityFrameworkCore;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.IO;

namespace Northwind.Entity
{
  public class NorthwindUtils
  {
    public static void FilteredIncludes()
    {
      using (var db = new Northwind())
      {
        Write("Enter a minimum for units in stock: ");
        string unitsInStock = ReadLine();
        int stock = int.Parse(unitsInStock);
        IQueryable<Category> cats = db.Categories
          .Include(c => c.Products.Where(p => p.Stock >= stock));

        foreach (Category c in cats)
        {
          WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of { stock} units in stock.");
          foreach (Product p in c.Products)
          {
            WriteLine($"  {p.ProductName} has {p.Stock} units in stock.");
          }
        }
      }
    }

    public static void QueryingCategories()
    {
      string jsonPath = Combine(CurrentDirectory, "categories.json");

      using (var db = new Northwind())
      {
        using (StreamWriter jsonStream = File.CreateText(jsonPath))
        {
          IQueryable<Category> cats = db.Categories;
          // create an object that will format as JSON
          var jss = new Newtonsoft.Json.JsonSerializer();
          // serialize the object graph into a string

          jss.Serialize(jsonStream, cats);

          foreach (Category cat in cats)
          {
            WriteLine($"{cat.CategoryName}");
          }

        }
      }
    }

    public static void QueryingProducts()
    {
      string jsonPath = Combine(CurrentDirectory, "products.json");

      using (var db = new Northwind())
      {
        using (StreamWriter jsonStream = File.CreateText(jsonPath))
        {
          IQueryable<Product> products = db.Products.OrderByDescending(product => product.Cost);
          var jss = new Newtonsoft.Json.JsonSerializer();
          jss.Serialize(jsonStream, products);
        }
      }
    }
  }
}
