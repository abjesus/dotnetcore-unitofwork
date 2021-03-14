using System.Collections.Generic;
using System.Linq;

namespace uow.Domain.Intefaces
{
  public interface IRepository<T>
  {
    IQueryable<T> GetAll();

    T GetById(int ind);

    void Create(T model);

    void Update(T model);

    void Delete(T model);
  }
}