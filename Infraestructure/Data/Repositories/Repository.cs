using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using uow.Domain.Intefaces;

namespace uow.Infraestructure.Data.Repositories
{

  public abstract class Repository<T> : IRepository<T> where T : class
  {
    private AppContext _context;

    public Repository(AppContext context)
    {
      _context = context;
    }

    public void Create(T model)
    {
      _context.Set<T>().Add(model);
    }

    public void Delete(T model)
    {
      _context.Set<T>().Remove(model);
    }

    public IEnumerable<T> GetAll()
    {
      return _context.Set<T>().ToList();
    }

    public T GetById(int id)
    {
      return _context.Set<T>().Find(id);
    }

    public void Update(T model)
    {
      _context.Entry(model).State = EntityState.Modified;
    }
  }
}