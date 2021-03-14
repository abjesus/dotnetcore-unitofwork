using System.Threading.Tasks;
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
    public async Task<ActionResult<PagedList<ProductModel>>> Get([FromServices] IUnitOfWork unityOfWork, [FromQuery] PaginationParams paginationParams)
    {
      return await unityOfWork.ProductRepository.GetAll(paginationParams);
    }

    [HttpGet]
    [Route("seach/{description}")]
    public async Task<ActionResult<PagedList<ProductModel>>> Search([FromServices] IUnitOfWork unitOfWork, string description, [FromQuery] PaginationParams paginationParams)
    {
      if(!string.IsNullOrEmpty(description))
      {
        return await unitOfWork.ProductRepository.GetProductsByDescription(description, paginationParams);
      }

      return new PagedList<ProductModel>();
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
    public async Task<ActionResult<ProductModel>> Put(
      [FromServices] IUnitOfWork unitOfWork,
      [FromBody] ProductModel model
    )
    {
      if(ModelState.IsValid)
      {
        var productModel = await unitOfWork.ProductRepository.GetById(model.Id);
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
    public async Task<ActionResult<ProductModel>> Delete([FromServices] IUnitOfWork unitOfWork, int id)
    {
      if(id > 0)
      {
        var productModel = await unitOfWork.ProductRepository.GetById(id);
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