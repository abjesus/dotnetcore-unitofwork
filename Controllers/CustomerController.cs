using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using uow.Domain.Intefaces;
using uow.Domain.Models;

namespace uow.Controllers
{
  [ApiController]
  [Route("v1/customers")]
  public class CustomerController : ControllerBase
  {
    [HttpGet]
    [Route("")]
    public ActionResult<List<CustomerModel>> Get([FromServices] IUnitOfWork unitOfWork)
    {
      var customers = unitOfWork.CustomerRepository.GetAll();
      return customers.ToList();
    }

    [HttpGet]
    [Route("search/{name}")]
    public ActionResult<List<CustomerModel>> Search([FromServices] IUnitOfWork unitOfWork, string name)
    {
      if(!string.IsNullOrEmpty(name))
      {
        return unitOfWork.CustomerRepository.SearchCustomersByName(name);
      }

      return new List<CustomerModel>();
    }

    [HttpPost]
    [Route("")]
    public ActionResult<CustomerModel> Post(
      [FromServices] IUnitOfWork unitOfWork,
      [FromBody] CustomerModel model)
    {
      if (ModelState.IsValid)
      {
        unitOfWork.CustomerRepository.Create(model);
        unitOfWork.Commit();
        
        return model;
      }

      return BadRequest(ModelState);
    }

    [HttpPut]
    [Route("")]
    public ActionResult<CustomerModel> Put(
      [FromServices] IUnitOfWork unitOfWork,
      [FromBody] CustomerModel model
    )
    {
      if(ModelState.IsValid)
      {
        var customerModel = unitOfWork.CustomerRepository.GetById(model.Id);
        
        if(customerModel != null && customerModel.Id > 0)
        {
          customerModel.Name = model.Name;

          unitOfWork.CustomerRepository.Update(customerModel);
          unitOfWork.Commit();
        }

        return customerModel;
      }

      return BadRequest(ModelState);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<CustomerModel> Delete([FromServices] IUnitOfWork unitOfWork, int id)
    {
      if(id > 0)
      {
        var customerModel = unitOfWork.CustomerRepository.GetById(id);

        if(customerModel != null && customerModel.Id > 0)
        {
          unitOfWork.CustomerRepository.Delete(customerModel);
          unitOfWork.Commit();
        }       

        return customerModel;
      }

      return BadRequest("id is not valid");
    }
  }
}