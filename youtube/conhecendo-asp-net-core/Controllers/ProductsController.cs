using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_core_api.Data;
using asp_net_core_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_net_core_api.Controllers
{
  [ApiController]
  [Route("v1/products")]
  public class ProductsController : ControllerBase
  {
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Product>>> List([FromServices] DataContext context)
    {
      List<Product> products;

      products = await context.Products.Include(
        product => product.Category
      ).ToListAsync();

      return products;
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Product>> Find([FromServices] DataContext context, int id)
    {
      Product findProduct = await context.Products
        .Include(product => product.Category)
        .AsNoTracking()
        .FirstOrDefaultAsync(product => product.Id == id);

      return findProduct;
    }

    [HttpGet]
    [Route("categories/{categoryId:int}")]
    public async Task<ActionResult<List<Product>>> ListByCategory(
      [FromServices] DataContext context,
      int categoryId)
    {
      List<Product> products;

      products = await context.Products
      .Include(product => product.Category)
      .AsNoTracking()
      .Where(product => product.CategoryId == categoryId)
      .ToListAsync();

      return products;
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Product>> Create(
          [FromServices] DataContext context,
          [FromBody] Product model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      context.Products.Add(model);

      await context.SaveChangesAsync();

      return model;
    }
  }
}
