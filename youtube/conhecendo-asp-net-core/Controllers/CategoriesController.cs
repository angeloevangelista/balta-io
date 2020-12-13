using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asp_net_core_api.Data;
using asp_net_core_api.Models;

namespace asp_net_core_api.Controllers
{
  [ApiController]
  [Route("v1/categories")]
  public class CategoriesController : ControllerBase
  {
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Category>>> List([FromServices] DataContext context)
    {
      List<Category> categories = await context.Categories.ToListAsync();

      return categories;
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Category>> Create(
      [FromServices] DataContext context,
      [FromBody] Category model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      context.Categories.Add(model);

      await context.SaveChangesAsync();

      return model;
    }
  }
}
