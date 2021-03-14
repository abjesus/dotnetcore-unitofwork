using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using uow.Domain.Intefaces;
using uow.Domain.Models;
using uow.Extensions;

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

    public async Task<PagedList<T>> GetAll(PaginationParams paginationParams = null)
    {
      return await GetQuery()
        .ToPagedList(paginationParams?.Page ?? 1, paginationParams?.PageSize ?? 10);
    }

    public async Task<T> GetById(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public void Update(T model)
    {
      _context.Entry(model).State = EntityState.Modified;
    }

    protected IQueryable<T> GetQuery()
    {
      return _context.Set<T>().AsNoTracking();
    }
  }
}