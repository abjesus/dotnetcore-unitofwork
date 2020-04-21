using System.Collections.Generic;
using uow.Domain.Models;

namespace uow.Domain.Intefaces
{
  public interface IProductRepository : IRepository<ProductModel>
  {
    List<ProductModel> GetProductsByDescription(string description);
  }
}