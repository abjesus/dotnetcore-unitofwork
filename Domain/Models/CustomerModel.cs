using System.ComponentModel.DataAnnotations;

namespace uow.Domain.Models
{
  public class CustomerModel 
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
  }
}