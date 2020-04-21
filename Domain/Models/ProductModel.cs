using System.ComponentModel.DataAnnotations;

namespace uow.Domain.Models
{
  public class ProductModel
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Description { get; set; }
  }
}