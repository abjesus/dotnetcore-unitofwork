using uow.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using uow.Domain.Intefaces;

namespace uow.Infraestructure.Data.Repositories
{
  public class CustomerRepository : Repository<CustomerModel>, ICustomerRepository
  {
    public CustomerRepository(AppContext context) : base(context)
    {
    }

    public List<CustomerModel> SearchCustomersByName(string name)
    {
      return GetAll()
        .Where(cus => cus.Name.Equals(name))
        .ToList();
    }
  }
}