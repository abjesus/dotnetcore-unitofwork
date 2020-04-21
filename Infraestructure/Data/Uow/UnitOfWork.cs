using System;
using uow.Domain.Intefaces;
using uow.Domain.Models;
using uow.Infraestructure.Data.Repositories;

namespace uow.Infraestructure.Data.Uow
{
  public class UnitOfWork : IUnitOfWork, IDisposable
  {
    private AppContext _context;
    private CustomerRepository _customerRepository;
    private ProductRepository _productRepository;
    
    public ICustomerRepository CustomerRepository 
    {
      get
      {
        if(_customerRepository == null)
        {
          _customerRepository = new CustomerRepository(_context);
        }
        return _customerRepository;
      }
    }

    public IProductRepository ProductRepository 
    {
      get
      {
        if(_productRepository == null)
        {
          _productRepository = new ProductRepository(_context);
        }
        return _productRepository;
      }
    }

    public UnitOfWork()
    {
      _context = new AppContext(AppContext.GetOptions());
    }

    public void Commit()
    {
      _context.SaveChanges();
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
      if(!disposed && disposing)
      {
        _context.Dispose();
      }

      disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
    }
  }
}