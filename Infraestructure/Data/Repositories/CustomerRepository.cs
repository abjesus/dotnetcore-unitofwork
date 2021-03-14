using uow.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using uow.Domain.Intefaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace uow.Infraestructure.Data.Repositories
{
  public class CustomerRepository : Repository<CustomerModel>, ICustomerRepository
  {
    public CustomerRepository(AppContext context) : base(context)
    {
    }

    public async Task<List<CustomerModel>> SearchCustomersByName(string name)
    {
      return await GetQuery()
        .Where(cus => cus.Name.Equals(name))
        .ToListAsync();
    }
  }
}