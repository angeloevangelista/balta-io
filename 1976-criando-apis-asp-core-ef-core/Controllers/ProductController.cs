using System;
using System.Collections.Generic;
using System.Linq;
using crud_based_baltaio.Data;
using crud_based_baltaio.Models;
using crud_based_baltaio.ViewModels;
using crud_based_baltaio.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_based_baltaio.Controllers
{
  [Route("v1/products")]
  public class ProductController
  {
    private readonly AppDataContext _context;

    public ProductController(AppDataContext context)
    {
      this._context = context;
    }

    [HttpGet]
    public IEnumerable<ListProductViewModel> Get()
    {
      return this._context.Products
      .Include(product => product.Category)
      .Select(product => new ListProductViewModel()
      {
        Id = product.Id,
        Title = product.Title,
        Price = product.Price,
        CategoryId = product.CategoryId,
        Category = product.Category.Title,
      })
      .AsNoTracking()
      .ToList();
    }


    [HttpGet]
    [Route("{productId}")]
    public Product Get(int productId)
    {
      return this._context.Products
        .AsNoTracking()
        .FirstOrDefault(product => Equals(product.Id, productId));
    }

    [HttpPost]
    public ResultViewModel Post([FromBody] EditorProductViewModel model)
    {
      Product product = new Product()
      {
        Title = model.Title,
        Image = model.Image,
        Price = model.Price,
        Quantity = model.Quantity,
        CategoryId = model.CategoryId,
        Description = model.Description,
        CreateDate = DateTime.Now,
        LastUpdateDate = DateTime.Now,
      };

      this._context.Products.Add(product);
      this._context.SaveChanges();

      return new ResultViewModel()
      {
        Success = true,
        Message = "Produto cadastrado com sucesso.",
        Data = product
      };
    }

    [HttpPut]
    public ResultViewModel Put([FromBody] EditorProductViewModel model)
    {
      Product product = this._context.Products.Find(model.Id);

      product.Title = model.Title;
      product.Image = model.Image;
      product.Price = model.Price;
      product.Quantity = model.Quantity;
      product.CategoryId = model.CategoryId;
      product.Description = model.Description;
      product.LastUpdateDate = DateTime.Now;

      this._context.Entry<Product>(product).State = EntityState.Modified;
      this._context.SaveChanges();

      return new ResultViewModel()
      {
        Success = true,
        Message = "Produto atualizado com sucesso.",
        Data = product,
      };
    }
  }
}
