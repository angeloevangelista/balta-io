using System.ComponentModel.DataAnnotations;
using asp_net_core_api.Models;

namespace asp_net_core_api.Models
{
  public class Product
  {
    [Key]
    public int Id { get; set; }

    [MaxLength(60, ErrorMessage = "Este campo deve conter no máximo 60 caracteres.")]
    [MinLength(3, ErrorMessage = "Este campo deve conter no mínimo 3 caracteres.")]
    public string Title { get; set; }

    [MaxLength(1024, ErrorMessage = "Este campo deve conter, no máximo, 1024 caracteres.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior do que zero.")]
    public decimal price { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida.")]
    public int CategoryId { get; set; }

    public Category Category { get; set; }
  }
}
