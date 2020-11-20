using System.Collections.Generic;

namespace crud_based_baltaio.Models
{
  public class Category
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<Product> Products { get; set; }
  }
}
