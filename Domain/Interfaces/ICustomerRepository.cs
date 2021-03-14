using System.Collections.Generic;
using System.Threading.Tasks;
using uow.Domain.Models;

namespace uow.Domain.Intefaces
{
  public interface ICustomerRepository : IRepository<CustomerModel>
  {
    Task<List<CustomerModel>> SearchCustomersByName(string name);
  }
}