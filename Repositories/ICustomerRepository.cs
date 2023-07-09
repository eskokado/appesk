using X.PagedList;

namespace appesk.Repositorties
{
  public interface ICustomerRepository
  {
    CustomerModel Create(CustomerModel customer);
    CustomerModel Update(CustomerModel customer);
    IPagedList<CustomerModel> ListPerPage(int pageNumber, int pageSize);
    CustomerModel? FindById(int id);

    bool DeleteById(int id);
  }
}