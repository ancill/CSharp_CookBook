using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Northwind.Entity
{
  public class Category
  {
    // these properties map to columns in the database
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }

    [Column(TypeName = "ntext")]
    public string Description { get; set; }
    // defines a navigation property for related rows

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual ICollection<Product> Products { get; set; }
    public Category()
    {
      // to enable developers to add products to a Category we must
      // initialize the navigation property to an empty collection
      this.Products = new HashSet<Product>();
    }
  }
}
