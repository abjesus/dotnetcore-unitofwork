using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uow.Domain.Intefaces;
using uow.Domain.Models;
using uow.Extensions;

namespace uow.Infraestructure.Data.Repositories
{
  public class ProductRepository : Repository<ProductModel>, IProductRepository
  {
    public ProductRepository(AppContext context) : base(context)
    {
    }

    public async Task<PagedList<ProductModel>> GetProductsByDescription(string description, PaginationParams paginationParams = null)
    {

      return await GetQuery()
          .Where(prod => prod.Description.Equals(description))
          .ToPagedList(page: paginationParams?.Page ?? 1, pageSize: paginationParams?.PageSize ?? 10);
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