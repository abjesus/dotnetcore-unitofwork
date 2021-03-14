using System.Threading.Tasks;
using uow.Domain.Models;

namespace uow.Domain.Intefaces
{
  public interface IRepository<T>
  {
    Task<PagedList<T>> GetAll(PaginationParams paginationParams = null);

    Task<T> GetById(int ind);

    void Create(T model);

    void Update(T model);

    void Delete(T model);
  }
}