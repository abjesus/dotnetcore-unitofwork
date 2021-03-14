namespace uow.Domain.Intefaces
{
  public interface IUnitOfWork
  {
    ICustomerRepository CustomerRepository { get; }
    IProductRepository ProductRepository { get; }
    void Commit();

  }
}