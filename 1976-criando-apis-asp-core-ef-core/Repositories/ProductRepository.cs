using System;
using System.Collections.Generic;
using System.Linq;
using crud_based_baltaio.Data;
using crud_based_baltaio.Models;
using crud_based_baltaio.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;

namespace crud_based_baltaio.Repositories
{
  public class ProductRepository
  {
    private readonly AppDataContext _context;

    public ProductRepository(AppDataContext context)
    {
      this._context = context;
    }
    public IEnumerable<ListProductViewModel> List()
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

    public Product Find(int productId)
    {
      return this._context.Products.Find(productId);
    }
    public void Save(Product product)
    {
      this._context.Products.Add(product);
      this._context.SaveChanges();
    }

    public void Update(Product product)
    {
      Product foundProduct = this.Find(product.Id);

      if (Equals(foundProduct, null))
        throw new Exception("Produto não encontrado.");

      this._context.Entry<Product>(product).State = EntityState.Modified;
      this._context.SaveChanges();
    }
  }
}
