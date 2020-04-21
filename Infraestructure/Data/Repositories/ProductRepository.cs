using System.Collections.Generic;
using System.Linq;
using uow.Domain.Intefaces;
using uow.Domain.Models;

namespace uow.Infraestructure.Data.Repositories
{
  public class ProductRepository : Repository<ProductModel>, IProductRepository
  {
    public ProductRepository(AppContext context) : base(context)
    {
    }

    public List<ProductModel> GetProductsByDescription(string description)
    {
      return GetAll()
        .Where(prod => prod.Description.Equals(description))
        .ToList();
    }

    public override bool Equals(object obj)
    {
      return base.Equals(obj);
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}