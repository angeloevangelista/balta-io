using System;
using System.Collections.Generic;
using System.Linq;
using crud_based_baltaio.Models;
using crud_based_baltaio.Repositories;
using crud_based_baltaio.ViewModels;
using crud_based_baltaio.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_based_baltaio.Controllers
{
  [Route("v1/products")]
  public class ProductController
  {
    private readonly ProductRepository _repository;

    public ProductController(ProductRepository repository)
    {
      this._repository = repository;
    }

    [HttpGet]
    public IEnumerable<ListProductViewModel> Get()
    {
      return this._repository.List();
    }


    [HttpGet]
    [Route("{productId}")]
    public Product Get(int productId)
    {
      return this._repository.Find(productId);
    }

    [HttpPost]
    public ResultViewModel Post([FromBody] EditorProductViewModel model)
    {
      model.Validate();

      if (model.Invalid)
        return new ResultViewModel()
        {
          Success = false,
          Message = "Não foi possível cadastrar o produto.",
          Data = model.Notifications,
        };

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

      this._repository.Save(product);

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
      model.Validate();

      if (model.Invalid)
        return new ResultViewModel
        {
          Success = false,
          Message = "Não foi possível alterar o produto",
          Data = model.Notifications
        };

      Product product = this._repository.Find(model.Id);

      product.Title = model.Title;
      product.Image = model.Image;
      product.Price = model.Price;
      product.Quantity = model.Quantity;
      product.CategoryId = model.CategoryId;
      product.Description = model.Description;
      product.LastUpdateDate = DateTime.Now;

      this._repository.Update(product);

      return new ResultViewModel()
      {
        Success = true,
        Message = "Produto atualizado com sucesso.",
        Data = product,
      };
    }
  }
}
