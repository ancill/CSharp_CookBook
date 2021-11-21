using Microsoft.EntityFrameworkCore.ChangeTracking; // EntityEntry<t>
using Packt.Shared;
using System.Collections.Concurrent;


namespace Northwind.WebApi.Repositories;
public class CustomerRepository : ICustomerRepository
{
  // use static thread safe dict field to cache the customers
  private static ConcurrentDictionary<string, Customer>? customersCache;

  // use an instance data context field because it should not be
  // cached due to their internal caching
  private NorthwindContext db;
  public CustomerRepository(NorthwindContext injectedContext)
  {
    db = injectedContext;
    // pre-load customers from database as a normal
    // Dictionary with CustomerId as key
    // then convert to a thread-safe ConcurrentDictionary
    if (customersCache is null)
    {
      customersCache = new ConcurrentDictionary<string, Customer>(
        db.Customers.ToDictionary(c => c.CustomerId));
    }
  }
  public async Task<Customer?> CreateAsync(Customer c)
  {
    c.CustomerId = c.CustomerId.ToUpper();
    // add to Db by EFcore
    EntityEntry<Customer> added = await db.Customers.AddAsync(c);
    int affected = await db.SaveChangesAsync();
    if (affected == 1)
    {
      if (customersCache is null) return c;
      // if the customer is new, add it to cache, else
      // call UpdateCache method
      return customersCache.AddOrUpdate(c.CustomerId, c, UpdateCache);
    }
    else
    {
      return null;
    }
  }

  public async Task<bool?> DeleteAsync(string id)
  {
    id = id.ToUpper();
    // remove from database
    Customer? c = db.Customers.Find(id);
    if (c is null) return null;
    db.Customers.Remove(c);
    int affected = await db.SaveChangesAsync();
    if (affected == 1)
    {
      if (customersCache is null) return null;
      // remove from cache
      return customersCache.TryRemove(id, out c);
    }
    else
    {
      return null;
    }
  }

  public Task<IEnumerable<Customer>> RetrieveAllAsync()
  {
    return Task.FromResult(customersCache is null ?
     Enumerable.Empty<Customer>() : customersCache.Values);
  }

  //read
  public Task<Customer?> RetrieveAsync(string id)
  {
    // for performance, get from cache
    id = id.ToUpper();
    if (customersCache is null) return null;
    customersCache.TryGetValue(id, out Customer? c);
    return Task.FromResult(c);
  }

  public async Task<Customer?> UpdateAsync(string id, Customer c)
  {
    // normilize customer id
    id = id.ToUpper();
    c.CustomerId = c.CustomerId.ToUpper();
    // update in database
    db.Customers.Update(c);
    int affected = await db.SaveChangesAsync();
    if (affected == 1)
    {
      return UpdateCache(id, c);
    }
    return null;
  }
  private Customer? UpdateCache(string id, Customer c)
  {
    Customer? old;
    if (customersCache is not null)
    {
      if (customersCache.TryGetValue(id, out old))
      {
        if (customersCache.TryUpdate(id, c, old))
        {
          return c;
        }
      }
    }
    return null;
  }



}
