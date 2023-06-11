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
      List<Product> products = await context.Products.Include(x => x.Category).AsNoTracking().ToListAsync();
      return Ok(products);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Product>>> GetById(
      [FromServices] DataContext context,
      int id
      )
    {
      Product? product = await context.Products.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

      return Ok(product);
    }

    [HttpGet]
    [Route("categories/{id:int}")]
    public async Task<ActionResult<List<Product>>> GetByCategory(
      int id,
      [FromServices] DataContext context
    )
    {
      List<Product> product = await context.Products
      .Include(x => x.Category)
      .AsNoTracking()
      .Where(x => x.CategoryId == id)
      .ToListAsync();

      return Ok(product);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Product>> Post(
    [FromBody] Product model,
    [FromServices] DataContext context)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        context.Products.Add(model);
        await context.SaveChangesAsync();
        return Ok(model);
      }
      catch (System.Exception)
      {
        return BadRequest(new { message = "Algo de errado aconteceu, tente novamente mais tarde" });
      }
    }
  }
}