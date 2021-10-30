using Microsoft.EntityFrameworkCore;

namespace Northwind.Entity
{
  // This manages the connection to the database
  public class Northwind : DbContext
  {
    // these properties map to tables in the database
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(
      DbContextOptionsBuilder optionsBuilder)
    {
      string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "./Database/Northwind.db");

      optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Filename={path}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // example of using Fluent Api instead of attributes
      // to limit the Length of a category name to 15
      modelBuilder.Entity<Category>()
        .Property(category => category.CategoryName)
        .IsRequired() // NOT NULL
        .HasMaxLength(15);

      // added to "Fix"the lack of decimal support in Sqlite
      modelBuilder.Entity<Product>()
        .Property(product => product.Cost)
        .HasConversion<double>();
      // global filter to remove discontinued products
      modelBuilder.Entity<Product>()
        .HasQueryFilter(p => !p.Discontinued);
    }
  }
}
