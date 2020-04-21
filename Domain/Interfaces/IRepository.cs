using System.Collections.Generic;

namespace uow.Domain.Intefaces
{
  public interface IRepository<T>
  {
    IEnumerable<T> GetAll();

    T GetById(int ind);

    void Create(T model);

    void Update(T model);

    void Delete(T model);
  }
}