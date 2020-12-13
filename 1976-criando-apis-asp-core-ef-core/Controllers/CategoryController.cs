using System;
using System.Collections.Generic;
using System.Linq;
using crud_based_baltaio.Data;
using crud_based_baltaio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_based_baltaio.Controllers
{
  [Route("v1/categories")]
  public class CategoryController : Controller
  {
    private readonly AppDataContext _context;

    public CategoryController(AppDataContext context)
    {
      this._context = context;
    }

    [HttpGet]
    public IEnumerable<Category> Get()
    {
      return this._context.Categories.AsNoTracking().ToList();
    }

    [HttpGet]
    [Route("{categoryId}")]
    public Category Get(int categoryId)
    {
      return this._context.Categories
        .AsNoTracking()
        .Where(category => Equals(category.Id, categoryId))
        .FirstOrDefault();
    }

    [HttpGet]
    [Route("{categoryId}/products")]
    public IEnumerable<Product> GetProducts(int categoryId)
    {
      return this._context.Products
        .AsNoTracking()
        .Where(product => Equals(product.CategoryId, categoryId))
        .ToList();
    }

    [HttpPost]
    public Category Post([FromBody] Category category)
    {
      this._context.Add(category);
      this._context.SaveChanges();

      return category;
    }

    [HttpPut]
    public Category Put([FromBody] Category category)
    {
      this._context.Entry<Category>(category).State = EntityState.Modified;
      this._context.SaveChanges();

      return category;
    }

    [HttpDelete]
    public Category Delete([FromBody] Category category)
    {
      Category foundCategory = this._context.Categories.FirstOrDefault(cat => Equals(cat.Id, category.Id));

      if (Equals(foundCategory, null))
        return null;

      this._context.Categories.Remove(category);
      this._context.SaveChanges();

      return category;
    }
  }
}
