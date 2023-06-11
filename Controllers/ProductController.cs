using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
  [Route("products")]
  public class ShopController : ControllerBase
  {
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Product>>> Get(
      [FromServices] DataContext context
    )
    {
      List<Product> products = await context.Products.AsNoTracking().ToListAsync();
      return Ok(products);
    }
  }
}