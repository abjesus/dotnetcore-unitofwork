using System.Threading.Tasks;
using uow.Domain.Models;

namespace uow.Domain.Intefaces
{
  public interface IProductRepository : IRepository<ProductModel>
  {
    Task<PagedList<ProductModel>> GetProductsByDescription(string description, PaginationParams paginationParams = null);
  }
}