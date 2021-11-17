using Microsoft.AspNetCore.Mvc; // [Route] , [ApiController]
using Packt.Shared; // Customer
using Northwind.WebApi.Repositories; // ICustomerRepository
namespace Northwind.WebApi.Controllers;
// base address: api/customers
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
  private readonly ICustomerRepository repo;
  // constructor injects repo registered in Startup
  public CustomerController(ICustomerRepository repo)
  {
    this.repo = repo;
  }

  // GET: api/customers
  // GET: api/customers/?country=[country]
}
