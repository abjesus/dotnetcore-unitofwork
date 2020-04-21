using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using uow.Domain.Intefaces;
using uow.Domain.Models;

namespace uow.Controllers
{
  [ApiController]
  [Route("v1/products")]
  public class ProductController : ControllerBase
  {
    [HttpGet]
    [Route("")]
    public ActionResult<List<ProductModel>> Get([FromServices] IUnitOfWork unityOfWork)
    {
      return unityOfWork.ProductRepository.GetAll().ToList();
    }

    [HttpGet]
    [Route("seach/{description}")]
    public ActionResult<List<ProductModel>> Search([FromServices] IUnitOfWork unitOfWork, string description)
    {
      if(!string.IsNullOrEmpty(description))
      {
        return unitOfWork.ProductRepository.GetProductsByDescription(description);
      }

      return new List<ProductModel>();
    }

    [HttpPost]
    [Route("")]
    public ActionResult<ProductModel> Post(
      [FromServices] IUnitOfWork unitOfWork,
      [FromBody] ProductModel model
    )
    {
      if(ModelState.IsValid)
      {
        unitOfWork.ProductRepository.Create(model);
        unitOfWork.Commit();

        return model;
      }

      return BadRequest(ModelState);
    }

    [HttpPut]
    [Route("")]
    public ActionResult<ProductModel> Put(
      [FromServices] IUnitOfWork unitOfWork,
      [FromBody] ProductModel model
    )
    {
      if(ModelState.IsValid)
      {
        var productModel = unitOfWork.ProductRepository.GetById(model.Id);
        if(productModel != null && productModel.Id > 0)
        {
          productModel.Description = model.Description;

          unitOfWork.ProductRepository.Update(productModel);
          unitOfWork.Commit();

          return productModel;
        }

        return productModel;
      }

      return BadRequest(ModelState);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<ProductModel> Delete([FromServices] IUnitOfWork unitOfWork, int id)
    {
      if(id > 0)
      {
        var productModel = unitOfWork.ProductRepository.GetById(id);
        if(productModel != null && productModel.Id > 0)
        {
          unitOfWork.ProductRepository.Delete(productModel);
          unitOfWork.Commit();

          return productModel;
        }

        return productModel;
      }

      return BadRequest("id is not valid");
    }
  }
}