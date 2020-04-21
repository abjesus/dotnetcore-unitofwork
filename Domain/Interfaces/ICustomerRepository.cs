using System.Collections.Generic;
using uow.Domain.Models;

namespace uow.Domain.Intefaces
{
  public interface ICustomerRepository : IRepository<CustomerModel>
  {
    List<CustomerModel> SearchCustomersByName(string name);
  }
}